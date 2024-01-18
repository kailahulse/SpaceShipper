using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipTriggerScript : MonoBehaviour
{
    public Animator ship;
    public GameObject PlayerResources;
    public PlayerResources playerResourcesScript;
    public int rocksNeeded = 2;
    public bool isShipDown;
    public bool nextLevel;
    public int matCollected;
    public bool returnShip;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        nextLevel = false;
        isShipDown = false;
        matCollected = 0;
        ship.SetBool("lowerShip", false);
        ship.SetBool("returnShip", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShipDown)
        {
            ship.SetBool("lowerShip", true);
            isShipDown = true;
        }
    }

    // In OnTriggerEnter, when player enters the trigger, checks if they have 
    // all the rocks needed and ends the level when completed. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerResourcesScript = PlayerResources.GetComponent<PlayerResources>();

            // Check if the PlayerResources script is found before accessing its variables
            if (playerResourcesScript != null)
            {
                matCollected = playerResourcesScript.RedOreValue +
                               playerResourcesScript.BlueOreValue +
                               playerResourcesScript.GreenOreValue +
                               playerResourcesScript.YellowOreValue +
                               playerResourcesScript.OrangeOreValue;
            }
            else
            {
                Debug.LogWarning("PlayerResources script not found on the PlayerResources GameObject.");
            }

            hasRocks();
        }
    }

    // hasRocks checks if the player has the necessary rocks with them
    // and does all necessary things to "end" the level.
    private void hasRocks()
    {
        if (matCollected >= rocksNeeded)
        {
            if (isShipDown)
            {
                Debug.Log("Has Rocks!");
                ship.SetBool("returnShip", true);
                isShipDown = false;
                Invoke(nameof(activateScreen), 3f);
            }
        }
        else
        {
            Debug.Log("Collect all rocks needed!");
        }
    }

    private void activateScreen()
    {
        SceneManager.LoadScene(4);
    }
}
