using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;
    
    void Start()
    {
        textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
        takingAway = false;

        if (secondsLeft <= 0)
        {
            SwitchToScene();
        }
    }

    void SwitchToScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(3);
    }
}
