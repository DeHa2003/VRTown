using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenePlayerControllerWithDrone : GameScenePlayerController
{
    protected override void InitializeStates()
    {
        playerStates = new Dictionary<Type, IPlayerState>();

        playerStates[typeof(PlayerDefaultState)] = new PlayerDefaultState();
        playerStates[typeof(PlayerCompletedState)] = new PlayerCompletedState();
        playerStates[typeof(PlayerDroneControlState)] = new PlayerDroneControlState();
        playerStates[typeof(PlayerFailedState_Wheel)] = new PlayerFailedState_Wheel();
        playerStates[typeof(PlayerFailedState_PedestrianCross)] = new PlayerFailedState_PedestrianCross();
    }

    public void SetPlayerDroneState()
    {
        SetState(GetState<PlayerDroneControlState>());
    }
}
