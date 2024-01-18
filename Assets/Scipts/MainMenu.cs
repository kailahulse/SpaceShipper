using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayTutButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else   
        Application.Quit();
#endif        
    }

    public void OnOptionButton()
    {
        SceneManager.LoadScene(5);

    }
}
