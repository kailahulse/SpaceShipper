using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public PlayerResources playerResources;
    public TextMeshProUGUI roundPromptText;
    public GameObject miningManager;

    // Separate variables for each ore type value
    public int requiredRedOre;
    public int requiredBlueOre;
    public int requiredGreenOre;
    public int requiredYellowOre;
    public int requiredOrangeOre;

    // UI Text elements to display the required rocks for each ore type
    public TextMeshProUGUI redOreRequiredText;
    public TextMeshProUGUI blueOreRequiredText;
    public TextMeshProUGUI greenOreRequiredText;
    public TextMeshProUGUI yellowOreRequiredText;
    public TextMeshProUGUI orangeOreRequiredText;

    private bool roundActive = false;

    private void Start()
    {
        UpdateRoundPromptText();
    }

    public void StartRound()
    {
        miningManager.SetActive(true); // Activate the MiningManager to allow mining
        roundActive = true;
    }

    public void EndRound()
    {
        miningManager.SetActive(false); // Deactivate the MiningManager to prevent further mining
        roundActive = false;
        // Perform any other actions to end the round or start a new one
        
        // Subtract the required ore amounts from player resources
        playerResources.RedOreValue -= requiredRedOre;
        playerResources.BlueOreValue -= requiredBlueOre;
        playerResources.GreenOreValue -= requiredGreenOre;
        playerResources.YellowOreValue -= requiredYellowOre;
        playerResources.OrangeOreValue -= requiredOrangeOre;
    }

    public void CollectOre(string oreType)
    {
        if (roundActive)
        {
            // Check which ore type was collected and update the required amount accordingly
            switch (oreType)
            {
                case "RedOre":
                    requiredRedOre--;
                    break;
                case "BlueOre":
                    requiredBlueOre--;
                    break;
                case "GreenOre":
                    requiredGreenOre--;
                    break;
                case "YellowOre":
                    requiredYellowOre--;
                    break;
                case "OrangeOre":
                    requiredOrangeOre--;
                    break;
            }

            // Update the round prompt text
            UpdateRoundPromptText();

            // Check if all required ores are collected
            if (requiredRedOre <= 0 && requiredBlueOre <= 0 && requiredGreenOre <= 0 &&
                requiredYellowOre <= 0 && requiredOrangeOre <= 0)
            {
                // If all required ores are collected, end the round
                EndRound();
            }
        }
    }

    public void SetRequiredOres(int red, int orange, int yellow, int green, int blue)
    {
        requiredRedOre = red;
        requiredOrangeOre = orange;
        requiredYellowOre = yellow;
        requiredGreenOre = green;
        requiredBlueOre = blue;


        // Update the round prompt text with the new required amounts
        UpdateRoundPromptText();
    }
    private void UpdateRoundPromptText()
    {
        // Update the round prompt text with the remaining ores to collect
        string promptText = "Next Shipment:\n"; // Add a new line after the main text

        // Display the required rocks for each ore type
        redOreRequiredText.text = $"Red Ore: {requiredRedOre}";
        blueOreRequiredText.text = $"Blue Ore: {requiredBlueOre}";
        greenOreRequiredText.text = $"Green Ore: {requiredGreenOre}";
        yellowOreRequiredText.text = $"Yellow Ore: {requiredYellowOre}";
        orangeOreRequiredText.text = $"Orange Ore: {requiredOrangeOre}";

        // Add a new line after each ore prompt
        promptText += redOreRequiredText.text + "\n";
        promptText += blueOreRequiredText.text + "\n";
        promptText += greenOreRequiredText.text + "\n";
        promptText += yellowOreRequiredText.text + "\n";
        promptText += orangeOreRequiredText.text + "\n";

        roundPromptText.text = promptText;
    }
}
