using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHealth : MonoBehaviour
{
    public int objectsHealth;
    [SerializeField] private PlayerResources playerResources;
    public string oreType { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        playerResources = GameObject.Find("Player Resources").GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsHealth <= 0)
        {
            // Update the corresponding ore type value based on the tag
            switch (oreType)
            {
                case "RedOre":
                    playerResources.RedOreValue += 1;
                    break;
                case "BlueOre":
                    playerResources.BlueOreValue += 1;
                    break;
                case "GreenOre":
                    playerResources.GreenOreValue += 1;
                    break;
                case "YellowOre":
                    playerResources.YellowOreValue += 1;
                    break;
                case "OrangeOre":
                    playerResources.OrangeOreValue += 1;
                    break;
                default:
                    break;
            }
            playerResources.OreCollected(oreType);
            Destroy(gameObject);
        }
    }
}
