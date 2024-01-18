using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject attack;
    
    void Start()
    {
        attack = transform.GetChild(13).gameObject; // Attack hitbox
    }

    // Enables the attack hitbox trigger
    void Attack()
    {
        // Debug.Log("Attack");
        attack.SetActive(true);
    }

    // Disables the attack hitbox trigger
    void EndAttack()
    {
        attack.SetActive(false);
    }
}
