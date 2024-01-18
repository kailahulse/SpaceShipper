using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    public int damage;
    [SerializeField] private float range;
    [SerializeField] private LayerMask mineableObject;
    [SerializeField] private ObjectsHealth objectsHealth;
    private Transform playerTransform;
    [SerializeField] private itemAppear itemAppear; // Reference to the ItemAppear script

    void Start()
    {
        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");
        if (playerCharacter != null)
        {
            playerTransform = playerCharacter.transform;
            itemAppear = playerCharacter.GetComponent<itemAppear>();
        }
        else
        {
            Debug.LogError("Player not found! Make sure to tag your player character with 'Player'.");
        }
    }


    void Update()
    {
        if (playerTransform == null || itemAppear == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (itemAppear.pickaxe) // Check if the pickaxe is equipped
            {
                // Calculate the mining direction based on the player's facing direction
                Vector3 miningDirection = playerTransform.forward;

                // Create a ray starting from the player's position in the mining direction
                Ray ray = new Ray(playerTransform.position, miningDirection);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, range, mineableObject))
                {
                    objectsHealth = hit.transform.GetComponent<ObjectsHealth>();
                    objectsHealth.oreType = hit.transform.tag;
                    objectsHealth.objectsHealth -= damage;
                }
            }
            else
            {
                // Player does not have the pickaxe equipped, so they can't mine.
                // Debug.Log("You need a pickaxe to mine!");
            }
        }
    }


}

