using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeUpgradeScript : MonoBehaviour
{
    [SerializeField] private bool inTrigger;
    [SerializeField] private int playerCoins;
    [SerializeField] private int minObjectHealth;
    public int upgradeCoinCost;
    public GameObject MiningManager;
    public MiningManager miningManagerScript;
    public GameObject coinResources;
    public CoinResources coinResourcesScript;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("In Trigger");
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
        upgradeCoinCost = 5;
        minObjectHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        coinResourcesScript = coinResources.GetComponent<CoinResources>();
        playerCoins = coinResourcesScript.value;
        if(inTrigger){
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if (upgradeCoinCost > 11) {
                    Debug.Log("no more upgrades");
                } else {
                    Debug.Log("Z Pressed");
                    upgradePickAxe();

                }
            }
        }
    }

    private void upgradePickAxe() 
    {
        if(playerCoins >= upgradeCoinCost)
        {
            miningManagerScript = MiningManager.GetComponent<MiningManager>();
            if(miningManagerScript.damage <= minObjectHealth)
            {
                miningManagerScript.damage = miningManagerScript.damage + 5;
                coinResourcesScript.value = coinResourcesScript.value - upgradeCoinCost;
                upgradeCoinCost+=2;

            } else {
                Debug.Log("You have reached the maximum upgrade level for this pickaxe");
            }
        } else {
            Debug.Log("Not enough coins.");
        }
    }
}