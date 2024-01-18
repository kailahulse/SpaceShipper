using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appear : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject dialogueBoxP1;
    public GameObject dialogueBoxP2;
    public GameObject dialogueBoxP3;
    public GameObject dialogueBoxP4;
    public GameObject axe;
    public int axeCost;
    public float proximity = 5f;
    private Transform player;
    private AxeUpgradeScript axeUpgradeScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        axeUpgradeScript = GameObject.FindGameObjectWithTag("Axe").GetComponent<AxeUpgradeScript>();
        dialogueBox = GameObject.FindGameObjectWithTag("dialogueP");
        dialogueBoxP1 = GameObject.FindGameObjectWithTag("dialogueP1");
        dialogueBoxP2 = GameObject.FindGameObjectWithTag("dialogueP2");
        dialogueBoxP3 = GameObject.FindGameObjectWithTag("dialogueP3");
        dialogueBoxP4 = GameObject.FindGameObjectWithTag("dialogueP4");

        dialogueBox.SetActive(false);
        dialogueBoxP1.SetActive(false);
        dialogueBoxP2.SetActive(false);
        dialogueBoxP3.SetActive(false);
        dialogueBoxP4.SetActive(false);
        
    }

    // Update is called once per frame
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // float distance = Vector3.Distance(transform.position, other.transform.position);
            // if (distance <= proximity)
            // {
                int axeCost = axeUpgradeScript.upgradeCoinCost; // Get the current axe cost
                Debug.Log("in here");
                if (axeCost == 5) {
                    dialogueBox.SetActive(true);
                } else if (axeCost == 7) {
                    dialogueBoxP1.SetActive(true);
                } else if (axeCost == 9) {
                    dialogueBoxP2.SetActive(true);
                } else if (axeCost == 11) {
                    dialogueBoxP3.SetActive(true);
                } else {
                    dialogueBoxP4.SetActive(true);
                }
           // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(false);
            dialogueBoxP1.SetActive(false);
            dialogueBoxP2.SetActive(false);
            dialogueBoxP3.SetActive(false);
            dialogueBoxP4.SetActive(false);
        }
    }
    // void Update()
    // {
    //     axe = GameObject.FindGameObjectWithTag("Axe");
    //     axeCost = axe.GetComponent<AxeUpgradeScript>().upgradeCoinCost;
    //     float distance = Vector3.Distance(transform.position, player.position);
    //     if (distance <= proximity)
    //     {
    //         if (axeCost == 5) {
    //             dialogueBox.SetActive(true);
    //         } else if (axeCost == 7) {
    //             dialogueBoxP1.SetActive(true);
    //         } else if (axeCost == 9) {
    //             dialogueBoxP2.SetActive(true);
    //         } else if (axeCost == 11) {
    //             dialogueBoxP3.SetActive(true);
    //         } else {
    //             dialogueBoxP4.SetActive(true);
    //         }
    //     } 
    //     else 
    //     {
    //         dialogueBox.SetActive(false);
    //         dialogueBoxP1.SetActive(false);
    //         dialogueBoxP2.SetActive(false);
    //         dialogueBoxP3.SetActive(false);
    //         dialogueBoxP4.SetActive(false);
    //     }
    // }
}
