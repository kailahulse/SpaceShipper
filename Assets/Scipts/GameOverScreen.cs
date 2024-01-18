using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ChangeSceneToBuildIndexZero()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeSceneToBuildIndexTwo()
    {
        SceneManager.LoadScene(2);
    }
}
