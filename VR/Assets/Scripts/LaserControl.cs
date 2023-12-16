using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LaserControl : PlayerComponentControl
{
    private HandButtons laser;

    private void Awake()
    {
        Debug.Log("Дочерний класс");
        laser = getPlayer.player.GetComponent<HandButtons>();
    }
    public void ActivateComponent(bool isActive)
    {
        //if (isActive)
        //{
        //    laser.AddLaserPointer();
        //}
        //else
        //{
        //    laser.RemoveLaserPointer();
        //}
    }
}
