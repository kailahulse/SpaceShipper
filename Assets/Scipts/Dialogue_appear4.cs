using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appear4 : MonoBehaviour
{
     public GameObject dialogueBox4;
    public float proximity = 7f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueBox4 = GameObject.FindGameObjectWithTag("dialogue4");

        dialogueBox4.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= proximity)
        {
            dialogueBox4
.SetActive(true);
        } 
        else 
        {
            dialogueBox4
.SetActive(false);
        }
    }
}
