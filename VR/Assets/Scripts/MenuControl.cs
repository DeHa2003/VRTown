using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : PlayerComponentControl
{
    private PlayerMenuControl menuPanel;

    private void Awake()
    {
        Debug.Log("Дочерний класс");
        menuPanel = getPlayer.player.GetComponentInChildren<PlayerMenuControl>();
    }

    public void ActivateComponent(bool isActive)
    {
        if(menuPanel == null) { return; }
        menuPanel.enabled = isActive;
    }

}
