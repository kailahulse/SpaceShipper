using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appear5 : MonoBehaviour
{
     public GameObject dialogueBox2;
    public float proximity = 5f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueBox2 = GameObject.FindGameObjectWithTag("dialogue5");

        dialogueBox2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= proximity)
        {
            dialogueBox2.SetActive(true);
        } 
        else 
        {
            dialogueBox2.SetActive(false);
        }
    }
}
