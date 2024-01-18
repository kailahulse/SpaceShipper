using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeepBehavior : MonoBehaviour
{
    public GameObject dialogTrigger;
    ShopkeeperDialog triggerInfo;

    public GameObject dialogCanvas;

    int currentDialog;
    public GameObject[] dialogs;

    // Start is called before the first frame update
    void Start()
    {
        triggerInfo = dialogTrigger.GetComponent<ShopkeeperDialog>();
        currentDialog = 0;
    }

    void Update()
    {
        if (triggerInfo.targetSpotted)
        {
            Transform t = triggerInfo.target.transform;
            Vector3 newtarget = t.position;
            newtarget.y = transform.position.y;
            transform.LookAt(newtarget);

            dialogCanvas.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                dialogs[currentDialog].SetActive(false);
                currentDialog++;
                if (currentDialog == dialogs.Length)
                {
                    currentDialog = 0;
                }
                dialogs[currentDialog].SetActive(true);
            }
        }
        else
        {
            dialogCanvas.SetActive(false);
        } 
    }
}
