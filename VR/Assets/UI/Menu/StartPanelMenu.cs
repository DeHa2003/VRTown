using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartPanelMenu : FinishPanel
{
    [SerializeField] private List<BoxCollider> buttonsColliders;

    private void OnEnable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = true;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = false;
        }
    }

    public void OpenPanel(GameObject panel)
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
    }
    
    public void CloseMenu()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
