using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appaer6 : MonoBehaviour
{
     public GameObject dialogueBox6;
    public float proximity = 5f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueBox6 = GameObject.FindGameObjectWithTag("dialogue6");

        dialogueBox6.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= proximity)
        {
            dialogueBox6.SetActive(true);
        } 
        else 
        {
            dialogueBox6.SetActive(false);
        }
    }
}
