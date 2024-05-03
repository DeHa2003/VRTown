using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneScenePlayerController : PlayerController
{
    protected override void InitializeStates()
    {
        playerStates = new Dictionary<Type, IPlayerState>();

        playerStates[typeof(PlayerDefaultState)] = new PlayerDefaultState();
        playerStates[typeof(PlayerCompletedState)] = new PlayerCompletedState();
        playerStates[typeof(PlayerDroneControlState)] = new PlayerDroneControlState();
        playerStates[typeof(PlayerFailedState_Wheel)] = new PlayerFailedState_Wheel();
    }

    public void SetPlayerDroneState()
    {
        SetState(GetState<PlayerDroneControlState>());
    }
}
