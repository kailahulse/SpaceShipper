using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class It : MonoBehaviour
{
    public GameObject pickaxePlayer;
    // Update is called once per frame
    void Start()
    {
        pickaxePlayer = GameObject.FindWithTag("Pickaxe_player");
        // if (pickaxePlayer != null) {
        //     pickaxePlayer.SetActive(false);
        // } else {
        //         Debug.LogError("not found");
        //     }
    }

    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Pickaxe_pedastal")) {
            print("here!");
            //if (pickaxePlayer != null) {
                pickaxePlayer.SetActive(false);

           // }
        }

    }
}
