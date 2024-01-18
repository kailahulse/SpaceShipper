using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUpgrade : MonoBehaviour
{
    public bool inUpgradeRange;
    public GameObject player;
    public CoinResources coins;
    public int coinPrice;

    // Start is called before the first frame update
    void Start()
    {
        inUpgradeRange = false;
        coinPrice = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && inUpgradeRange && CanAfford())
        {
            player.transform.GetChild(2).gameObject.SetActive(true); // EnemyHitbox must be active to update damage
            player.GetComponentInChildren<EnemyHitbox>().Upgrade();
            player.transform.GetChild(2).gameObject.SetActive(false);

            coins.value -= coinPrice;
            coinPrice += 4;
        }
    }

    bool CanAfford()
    {
        if (coinPrice > 13) {
            return false;
        }
        if (coins.value > coinPrice)
        {
            return true;
        }

        Debug.Log("Can't afford!");
        return false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player = collider.gameObject;
            inUpgradeRange = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inUpgradeRange = false;
        }
    }
}
