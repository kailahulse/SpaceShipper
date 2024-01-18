using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinResources : MonoBehaviour
{
    public int value;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = value.ToString();
    }

    public void AddCoins(int amount)
    {
        value += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = value.ToString();
    }

}
