using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerResources : MonoBehaviour
{
    // Add separate variables for each ore type value
    public int RedOreValue;
    public int BlueOreValue;
    public int GreenOreValue;
    public int YellowOreValue;
    public int OrangeOreValue;

    [SerializeField] private TextMeshProUGUI redOreText;
    [SerializeField] private TextMeshProUGUI blueOreText;
    [SerializeField] private TextMeshProUGUI greenOreText;
    [SerializeField] private TextMeshProUGUI yellowOreText;
    [SerializeField] private TextMeshProUGUI orangeOreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text for each ore type value
        redOreText.text = RedOreValue.ToString();
        blueOreText.text = BlueOreValue.ToString();
        greenOreText.text = GreenOreValue.ToString();
        yellowOreText.text = YellowOreValue.ToString();
        orangeOreText.text = OrangeOreValue.ToString();
    }
    
    public void OreCollected(string oreType)
    {
        FindObjectOfType<RoundManager>().CollectOre(oreType);
    }
}
