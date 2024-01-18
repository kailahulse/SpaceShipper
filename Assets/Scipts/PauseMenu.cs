using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionPanel;
    private bool isPaused;
    private bool optionOpen;
    private float savedTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused) 
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                if(optionOpen) 
                {
                    pausePanel.SetActive(true);
                    optionPanel.SetActive(false);
                    optionOpen = false;
                } else {
                    pausePanel.SetActive(false);
                    optionPanel.SetActive(true);
                    optionOpen = true;
                }
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                Exit();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused && !optionOpen)
            {
                Unpause();
            } else if (!optionOpen){
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else   
        Application.Quit();
#endif        
    }
}
