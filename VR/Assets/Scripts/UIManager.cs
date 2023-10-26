using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> uiObjs;

    public void CloseAllUiObjects(GameObject panel)
    {
        for (int i = 0; i < uiObjs.Count; i++)
        {
            uiObjs[i].SetActive(false);
        }

        if (panel != null)
            OpenUI(panel);
    }

    public void OpenUI(GameObject UIPanel)
    {
        UIPanel.SetActive(true);
    }
}
