using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appearS : MonoBehaviour
{
    public GameObject dialogueBox1;
    public GameObject dialogueBoxS2;
    public GameObject dialogueBoxS3;
    public GameObject dialogueBoxS4;
    public float proximity = 5f;
    private Transform player;
    private SwordUpgrade swordUpgrade;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        swordUpgrade = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordUpgrade>();
        dialogueBox1 = GameObject.FindGameObjectWithTag("dialogueS");
        dialogueBoxS2 = GameObject.FindGameObjectWithTag("dialogueS2");
        dialogueBoxS3 = GameObject.FindGameObjectWithTag("dialogueS3");
        dialogueBoxS4 = GameObject.FindGameObjectWithTag("dialogueS4");
       
        dialogueBox1.SetActive(false);
        dialogueBoxS2.SetActive(false);
        dialogueBoxS3.SetActive(false);
        dialogueBoxS4.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int swordCost = swordUpgrade.coinPrice; // Get the current axe cost
            //Debug.Log("in here");
            Debug.Log("my cost" + swordCost);
            if (swordCost == 5) {
                dialogueBox1.SetActive(true);
            } else if (swordCost == 9) {
                dialogueBoxS2.SetActive(true);
            } else if (swordCost == 13) {
                dialogueBoxS3.SetActive(true);
            } else {
                dialogueBoxS4.SetActive(true);
                }
           // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox1.SetActive(false);
            dialogueBoxS2.SetActive(false);
            dialogueBoxS3.SetActive(false);
            dialogueBoxS4.SetActive(false);
        }
    }

}
