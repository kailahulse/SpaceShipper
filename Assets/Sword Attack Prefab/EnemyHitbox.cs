using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public int damage;

    void Start()
    {
        damage = 1;
    }

    // Increases damage by 1
    public void Upgrade()
    {
        damage++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player hit the enemy.");
            other.gameObject.GetComponentInChildren<EnemyMovement>().TakeDamage(damage);
        }
        if (other.CompareTag("RedEnemy"))
        {
            Debug.Log("Player hit the enemy.");
            other.gameObject.GetComponentInChildren<RedEnemyMovement>().TakeDamage(damage);
        }
    }
}
