using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseGameModePanel : ColliderPanel
{
    //private void OnEnable()
    //{
    //    for (int i = 0; i < buttonsColliders.Count; i++)
    //    {
    //        buttonsColliders[i].enabled = true;
    //    }
    //}

    //private void OnDisable()
    //{
    //    for (int i = 0; i < buttonsColliders.Count; i++)
    //    {
    //        buttonsColliders[i].enabled = false;
    //    }
    //}

    public void OpenPanelGameVibor(GameObject panel)
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
