using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipTriggerScript2 : MonoBehaviour
{
    public Animator ship;
    public GameObject PlayerResources;
    public PlayerResources playerResourcesScript;
    public GameObject RoundManager;
    public RoundManager roundManagerScript;
    public int rocksNeeded = 2;
    public bool isShipDown;
    public int nextLevel;
    public int matCollected;
    public bool returnShip;
    public GameObject panel;
    public CoinResources coinResources;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("panel");
        //coinResources = coinResources.FindGameObjectWithTag("Coin");
        panel.SetActive(false);
        nextLevel = 0;
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
        if(playerResourcesScript.RedOreValue >= roundManagerScript.requiredRedOre &&
            playerResourcesScript.BlueOreValue >= roundManagerScript.requiredBlueOre &&
            playerResourcesScript.GreenOreValue >= roundManagerScript.requiredGreenOre &&
            playerResourcesScript.YellowOreValue >= roundManagerScript.requiredYellowOre &&
            playerResourcesScript.OrangeOreValue >= roundManagerScript.requiredOrangeOre) 
        {
            if (isShipDown)
            {
                Debug.Log("Has Rocks!");
                ship.SetBool("returnShip", true);
                isShipDown = false;
                Invoke(nameof(activateScreen), 3f);
                // Subtract required ore amount
                FindObjectOfType<PlayerResources>().RedOreValue -= roundManagerScript.requiredRedOre;
                FindObjectOfType<PlayerResources>().BlueOreValue -= roundManagerScript.requiredBlueOre;
                FindObjectOfType<PlayerResources>().GreenOreValue -= roundManagerScript.requiredGreenOre;
                FindObjectOfType<PlayerResources>().YellowOreValue -= roundManagerScript.requiredYellowOre;
                FindObjectOfType<PlayerResources>().OrangeOreValue -= roundManagerScript.requiredOrangeOre;
            }
        }
        else
        {
            Debug.Log("Collect all rocks needed!");
        }
    }

    private void activateScreen()
    {
       // panel = GameObject.FindGameObjectWithTag("panel");
        //panel.SetActive(true);
        coinResources.AddCoins(10);
        panel.SetActive(true);
        Invoke("panelSet", 5f);
        // Debug.Log("I have arrived");
        nextLevel++;
        reset();
    }

    void panelSet() {
        panel.SetActive(false);
    }

    void reset() {
        //nextLevel = false;
        isShipDown = false;
        matCollected = 0;
        ship.SetBool("lowerShip", false);
        ship.SetBool("returnShip", false);
    }
}

