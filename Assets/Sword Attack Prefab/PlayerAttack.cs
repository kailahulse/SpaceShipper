using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private itemAppear itemAppear;
    private Transform enemyHitboxTransform; // Reference to the EnemyHitbox GameObject's Transform

    bool canSwing; // Forces user to let go of left click to be able to attack again.

    void Start()
    {
        // Find and get the components from the player character
        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");
        if (playerCharacter != null)
        {
            itemAppear = playerCharacter.GetComponent<itemAppear>();
            enemyHitboxTransform = playerCharacter.transform.Find("EnemyHitbox");

            if (enemyHitboxTransform == null)
            {
                Debug.LogError("EnemyHitbox not found! Make sure it is a child of the player character.");
            }
            else
            {
                // Deactivate the EnemyHitbox by default
                enemyHitboxTransform.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Player not found! Make sure to tag your player character with 'Player'.");
        }
    }

    void Update()
    {
        if (itemAppear == null || enemyHitboxTransform == null)
        {
            return;
        }

        // Check for player input to attack with the sword (e.g., left mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the player has the sword equipped
            if (itemAppear.sword)
            {
                // Enable the enemy hitbox to detect collisions
                ActivateHitbox();
                Invoke("DeactivateHitbox", 0.1f);
            }
        }
    }

    public void ActivateHitbox()
    {
        enemyHitboxTransform.gameObject.SetActive(true);
    }

    public void DeactivateHitbox()
    {
        enemyHitboxTransform.gameObject.SetActive(false);
    }
}