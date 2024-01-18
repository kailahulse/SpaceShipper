using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        Wander, // Walk around randomly
        Chase,  // Chase player once spotted
        Evade   // Run away when health is low (may or may not implement, we'll see)
    }

    // Movement
    public EnemyState state;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    public Rigidbody rb;
    private float timer;
    public float wanderRadius;
    public float wanderTimer;

    // Attacking
    public float meleeRange;
    public GameObject attack; // Object with trigger hitbox

    // Animation
    public float speed = 0;
    Vector3 lastPosition = Vector3.zero;
    public Animator anim;

    // Vision
    private int visionRange = 10;   // Max range for raycast

    // Stats
    public EnemyStats stats;
    public bool invincible;

    // Coins
    [SerializeField] private CoinResources coinResources;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Wander;
        target = null;
        stats = GetComponent<EnemyStats>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //rb = GetComponent<Rigidbody>();

        invincible = false;
        coinResources = GameObject.Find("Coin Resources").GetComponent<CoinResources>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Wander)
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Wander();
            }
        }
        else if (state == EnemyState.Chase)
        {
            Chase();
        }
    }

    // Physics (like raycast) must happen here
    void FixedUpdate()
    {
        // Raycast
        Vector3 relativeForward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, relativeForward);
        RaycastHit hit;

        // if (Physics.Raycast(ray, out hit, visionRange))
        if (Physics.SphereCast(transform.position, 2.5f, relativeForward, out hit, visionRange))
        {
            GameObject spotted = hit.transform.gameObject;

            // If hits player (PLAYER MJST HAVE 'Player' TAG!)
            if (spotted.tag == "Player")
            {
                // Set target to the player and begin chasing
                // Debug.Log("Player spotted by enemy.");
                target = spotted.transform;
                state = EnemyState.Chase;
            }
        }

        // Speed check
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        
        if (speed > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (TargetInMeleeRange())
        {
            anim.SetBool("inMeleeRange", true);
            // Invoke("Attack", 0.3f);
            // Invoke("DisableAttack", 0.8f);
        }
        else
        {    
            anim.SetBool("inMeleeRange", false);
        }
    }

    void Wander()
    {
        // Debug.Log("Moving to new destination.");
        Vector3 newPos = RandomWander(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
        timer = 0;
    }

    void Chase()
    {
        if (TargetTooFar(5.0f))
        {
            // Player ran away far enough, go back to wandering
            state = EnemyState.Wander;
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    // Determines a random point on the NavMesh to travel to.
    public static Vector3 RandomWander(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

    // Returns true if player gets 'dist' units away in X and Z directions
    bool TargetTooFar(float dist)
    {
        if (target.position.x - transform.position.x > dist && target.position.z - transform.position.z > dist)
        {
            return true;
        }
        return false;
    }

    // Returns true if the target is being chased and is within melee range.
    bool TargetInMeleeRange()
    {
        if (target != null){
            if (target.position.x - transform.position.x < meleeRange && target.position.z - transform.position.z < meleeRange)
            {
                return true;
            }
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            invincible = true;

            // Update health
            stats.health -= damage;

            //KnockBack();

            // Play animation
            anim.SetBool("tookDamage", true);
            Invoke("EndDamage", 1.5f);

            if (stats.health <= 0)
            {
                anim.SetBool("isDead", true);
                Invoke("Die", 1.5f);
            }
        }
    }

    void KnockBack()
    {
        rb.AddForce(transform.forward * -1, ForceMode.Impulse);
        rb.AddForce(transform.up, ForceMode.Impulse);
    }

    void EndDamage()
    {
        anim.SetBool("tookDamage", false);
        invincible = false;
    }

    void Die()
    {
        coinResources.value += Random.Range(1,3);
        Destroy(gameObject);
    }
}
