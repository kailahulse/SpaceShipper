using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player hit with attack.");
            //other.gameObject.GetComponent<PlayerHealth>().health -= 15;
            
            Debug.Log("Player hit with attack.");
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.health -= 15;
            }
            
        }
    }
}
