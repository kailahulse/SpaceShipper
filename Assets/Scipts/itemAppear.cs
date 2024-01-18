using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAppear : MonoBehaviour
{
    public GameObject pickaxePlayer;
    public GameObject swordPlayer;
    public GameObject playerDash;
    public bool pickaxe = false;
    public bool sword = false;
    public AudioSource clip;
    // Update is called once per frame
    void Start()
    {
        pickaxePlayer = GameObject.FindWithTag("Pickaxe_player");
        swordPlayer = GameObject.FindWithTag("sword");
        if (pickaxePlayer != null) {
            pickaxePlayer.SetActive(pickaxe);
            swordPlayer.SetActive(sword);
        }
    }

    void Update()
    {
        if(sword == true || pickaxe == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click");
                clip.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            pickaxe = true;
            sword = false;
            pickaxePlayer.SetActive(pickaxe);
            swordPlayer.SetActive(sword);
        } if (Input.GetKeyDown(KeyCode.Alpha2)) {
            pickaxe = false;
            sword = true;
            pickaxePlayer.SetActive(pickaxe);
            swordPlayer.SetActive(sword);
        }
    }

}
