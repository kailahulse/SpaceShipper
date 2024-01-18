using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUpgradeScript : MonoBehaviour
{
    [SerializeField] private bool inTrigger;
    [SerializeField] private int playerCoins;
    public int upgradeCoinCost;
    public GameObject playerGameObject;
    public CharacterControls charactercontrols;
    public GameObject coinResources;
    public CoinResources coinResourcesScript;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("In trigger!");
            inTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        upgradeCoinCost = 3;
    }

    // Update is called once per frame
    void Update()
    {
        coinResourcesScript = coinResources.GetComponent<CoinResources>();
        playerCoins = coinResourcesScript.value;
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        charactercontrols = playerGameObject.GetComponent<CharacterControls>();
        if(inTrigger){
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Z pressed!");
                upgradeDash();
            }
        }
    }

    private void upgradeDash() 
    {
        // need to take off coins when upgrading
        if(playerCoins >= upgradeCoinCost)
        {
            if(charactercontrols.maxSpeedBoostCount <= 9)
            {
                Debug.Log("Upgrading dash");
                charactercontrols.maxSpeedBoostCount = charactercontrols.maxSpeedBoostCount + 1; 
                coinResourcesScript.value = coinResourcesScript.value - upgradeCoinCost;
            } else {
                Debug.Log("You have reached the maximum upgrade level for num dashes");
            }
        }
        Debug.Log("Not enough coins!");
    }
}
