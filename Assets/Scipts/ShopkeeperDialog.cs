using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperDialog : MonoBehaviour
{
    public GameObject target;
    public bool targetSpotted;

    void Start()
    {
        targetSpotted = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            targetSpotted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetSpotted = false;
        }
    }
}
