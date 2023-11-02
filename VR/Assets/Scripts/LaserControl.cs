using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LaserControl : PlayerComponentControl
{
    private Laser laser;

    private void Awake()
    {
        Debug.Log("Дочерний класс");
        laser = getPlayer.player.GetComponent<Laser>();
    }
    public void ActivateComponent(bool isActive)
    {
        if (isActive)
        {
            laser.AddLaserPointer();
        }
        else
        {
            laser.RemoveLaserPointer();
        }
    }
}
