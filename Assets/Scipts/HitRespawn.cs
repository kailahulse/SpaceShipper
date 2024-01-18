using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            transform.position = new Vector3(0f,3f,0f);
        }
    }
}

