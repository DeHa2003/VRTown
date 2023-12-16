using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : PlayerComponentControl
{
    private MenuPanel menuPanel;

    private void Awake()
    {
        Debug.Log("�������� �����");
        menuPanel = getPlayer.player.GetComponentInChildren<MenuPanel>();
    }

    public void ActivateComponent(bool isActive)
    {
        menuPanel.enabled = isActive;
    }

}
