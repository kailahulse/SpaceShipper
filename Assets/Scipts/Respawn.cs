using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform other;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ExampleCharacter")
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}

