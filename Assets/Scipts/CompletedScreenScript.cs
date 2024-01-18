using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CompletedScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("panel");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            panel.SetActive(false);
        }
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
