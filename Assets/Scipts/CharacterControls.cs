using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterControls : MonoBehaviour
{
    public float speed = 50.0f;
    public float airVelocity = 8f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public float jumpHeight = 2.0f;
    public float maxFallSpeed = 20.0f;
    public float rotateSpeed = 25f; // Speed the player rotates
    private Vector3 moveDir;
    public GameObject cam;
    private Rigidbody rb;

    private float distToGround;

    private bool canMove = true; // If player is not hit
    private bool isStunned = false;
    private bool wasStunned = false; // If player was stunned before getting stunned again
    private float pushForce;
    private Vector3 pushDir;

    public Vector3 checkPoint;
    private bool slide = false;

    private bool isBoosting = false;
    private float boostDuration = 5f;
    private float boostMultiplier = 2f;
    private float boostTimer = 0f;

	private bool isSpeedBoosting = false;
    private bool isAirSpeedBoosting = false;
    private float originalAirVelocity;
    public int maxSpeedBoostCount = 3; // Maximum number of times the speed boost can be used
    private int speedBoostCount = 0; // Current count of speed boost usage
	private Animator animator;


    private void Start()
    {
        // Get the distance to ground
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        checkPoint = transform.position;
        Cursor.visible = false;
		animator = GetComponent<Animator>();
        originalAirVelocity = airVelocity;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (moveDir.x != 0 || moveDir.z != 0)
            {
                Vector3 targetDir = moveDir; // Direction of the character

                targetDir.y = 0;
                if (targetDir == Vector3.zero)
                    targetDir = transform.forward;
                Quaternion tr = Quaternion.LookRotation(targetDir); // Rotation of the character to where it moves
                Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * rotateSpeed); // Rotate the character little by little
                transform.rotation = targetRotation;
            }

            float currentSpeed = isBoosting ? speed * boostMultiplier : speed;
			animator.SetFloat("Speed", currentSpeed);

            if (IsGrounded())
            {
                // Calculate how fast we should be moving
                Vector3 targetVelocity = moveDir;
                targetVelocity *= currentSpeed;

                // Apply a force that attempts to reach our target velocity
                Vector3 velocity = rb.velocity;
                if (targetVelocity.magnitude < velocity.magnitude) // If I'm slowing down the character
                {
                    targetVelocity = velocity;
                    rb.velocity /= 1.1f;
                }
                Vector3 velocityChange = (targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                if (!slide)
                {
                    if (Mathf.Abs(rb.velocity.magnitude) < currentSpeed * 1.0f)
                        rb.AddForce(velocityChange, ForceMode.VelocityChange);
                }
                else if (Mathf.Abs(rb.velocity.magnitude) < currentSpeed * 1.0f)
                {
                    rb.AddForce(moveDir * 0.15f, ForceMode.VelocityChange);
                }

                // Jump
                if (IsGrounded() && Input.GetButton("Jump"))
                {
                    rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                }
            }
            else
            {
                if (!slide)
                {
                    Vector3 targetVelocity = new Vector3(moveDir.x * airVelocity, rb.velocity.y, moveDir.z * airVelocity);
                    Vector3 velocity = rb.velocity;
                    Vector3 velocityChange = (targetVelocity - velocity);
                    velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                    velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                    rb.AddForce(velocityChange, ForceMode.VelocityChange);
                    if (velocity.y < -maxFallSpeed)
                        rb.velocity = new Vector3(velocity.x, -maxFallSpeed, velocity.z);
                }
                else if (Mathf.Abs(rb.velocity.magnitude) < currentSpeed * 1.0f)
                {
                    rb.AddForce(moveDir * 0.15f, ForceMode.VelocityChange);
                }
            }
        }
        else
        {
            rb.velocity = pushDir * pushForce;
        }

        // We apply gravity manually for more tuning control
        rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 v2 = v * cam.transform.forward; // Vertical axis to which I want to move with respect to the camera
        Vector3 h2 = h * cam.transform.right; // Horizontal axis to which I want to move with respect to the camera
        moveDir = (v2 + h2).normalized; // Global position to which I want to move with magnitude 1

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f))
        {
            if (hit.transform.tag == "Slide")
            {
                slide = true;
            }
            else
            {
                slide = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && speedBoostCount < maxSpeedBoostCount)
        {
            if (!isSpeedBoosting)
            {
                StartSpeedBoost();
                StartAirSpeedBoost();
                maxSpeedBoostCount--;
            }
            else
            {
                StopSpeedBoost();
                StopAirSpeedBoost();
            }
        }

        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= boostDuration)
            {
                StopSpeedBoost();
            }
        }
        if (Input.GetMouseButtonDown(0))
            {
            // Play punch animation
            animator.Play("Punch");
            }
    }


    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity, we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    public void HitPlayer(Vector3 velocityF, float time)
    {
        rb.velocity = velocityF;

        pushForce = velocityF.magnitude;
        pushDir = Vector3.Normalize(velocityF);
        StartCoroutine(Decrease(velocityF.magnitude, time));
    }

    public void LoadCheckPoint()
    {
        transform.position = checkPoint;
    }

    private IEnumerator Decrease(float value, float duration)
    {
        if (isStunned)
            wasStunned = true;
        isStunned = true;
        canMove = false;

        float delta = value / duration;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            yield return null;
            if (!slide) // Reduce the force if the ground isn't a slide
            {
                pushForce = pushForce - Time.deltaTime * delta;
                pushForce = pushForce < 0 ? 0 : pushForce;
            }
            rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0)); // Add gravity
        }

        if (wasStunned)
        {
            wasStunned = false;
        }
        else
        {
            isStunned = false;
            canMove = true;
        }
    }

    private void StartSpeedBoost()
    {
        if (!isBoosting)
        {
            isBoosting = true;
            boostTimer = 0f;
			animator.SetBool("SpeedBoost", true);
        }
    }

    private void StartAirSpeedBoost()
    {
        if (!isAirSpeedBoosting)
        {
            isAirSpeedBoosting = true;
            // Apply the air velocity increase
            airVelocity *= boostMultiplier;
        }
    }

    private void StopSpeedBoost()
    {
        if (isBoosting)
        {
            isBoosting = false;
			animator.SetBool("SpeedBoost", false);
            StopAirSpeedBoost();
        }
    }

    private void StopAirSpeedBoost()
    {
        if (isAirSpeedBoosting)
        {
            isAirSpeedBoosting = false;
            // Reset the air velocity to its original value
            airVelocity = originalAirVelocity;
            //Debug.Log("Stop Air Speed Boost was called");

        }
    }
}
