using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneUIExitPanel : ColliderPanel
{
    public GameScenePlayerController levelOneScenePlayerController;

    public override void Initialize()
    {
        base.Initialize();
        //levelOneScenePlayerController = Handler.Instance.GetController<LevelOneScenePlayerController>();
    }

    public void ExitPlay()
    {
        if(levelOneScenePlayerController != null) 
           levelOneScenePlayerController.SetPlayerDefaultState();
    }
}
