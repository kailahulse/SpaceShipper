using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthfull;
    public GameObject health5;
    public GameObject health4;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    public int health = 90;
    // Update is called once per frame
    void Start() {
        healthfull = GameObject.FindGameObjectWithTag("health_full");
        health5 = GameObject.FindGameObjectWithTag("health_5");
        health4 = GameObject.FindGameObjectWithTag("health_4");
        health3 = GameObject.FindGameObjectWithTag("health_3");
        health2 = GameObject.FindGameObjectWithTag("health_2");
        health1 = GameObject.FindGameObjectWithTag("health_1");
        healthfull.SetActive(true); // might be able to remove this
        health5.SetActive(false);
        health4.SetActive(false);
        health3.SetActive(false);
        health2.SetActive(false);
        health1.SetActive(false);
    }
    
    void Update()
    {
        playerHealth(health);
    }

    void playerHealth(int health) {
        switch (health)
        {
            case 90:
                healthfull.SetActive(true);
                health5.SetActive(false);
                health4.SetActive(false);
                health3.SetActive(false);
                health2.SetActive(false);
                health1.SetActive(false);
                break;
            case 75:
                healthfull.SetActive(false);
                health5.SetActive(true);
                break;
            case 60:
                health4.SetActive(true);
                health5.SetActive(false);
                break;
            case 45:
                health3.SetActive(true);
                health4.SetActive(false);
                break;
            case 30:
                health2.SetActive(true);
                health3.SetActive(false);
                break;
            case 15:
                health1.SetActive(true);
                health2.SetActive(false);
                break;
            case 0:
                SceneManager.LoadScene(3);
                break;
        }
    }
}
