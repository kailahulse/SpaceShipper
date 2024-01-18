using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appear_3 : MonoBehaviour
{
     public GameObject dialogueBox3;
    public float proximity = 7f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueBox3 = GameObject.FindGameObjectWithTag("dialogue3");

        dialogueBox3.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= proximity)
        {
            dialogueBox3.SetActive(true);
        } 
        else 
        {
            dialogueBox3.SetActive(false);
        }
    }
}
