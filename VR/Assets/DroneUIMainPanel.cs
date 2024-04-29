using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneUIMainPanel : ColliderPanel
{
    public LevelOneScenePlayerController controller;
    public override void Initialize()
    {
        base.Initialize();
        //controller = Handler.Instance.GetController<LevelOneScenePlayerController>();
    }
    public void StartPlayDrone()
    {
        if(controller != null)
           controller.SetPlayerDroneState();
    }
}
