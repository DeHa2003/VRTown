using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScenePlayerController : PlayerController
{
    protected override void InitializeStates()
    {
        playerStates = new Dictionary<Type, IPlayerState>();

        playerStates[typeof(PlayerInHouseState)] = new PlayerInHouseState();
    }

    protected override void SetStartState()
    {
        SetHouseStatus();
    }

    public void SetHouseStatus()
    {
        SetState(GetState<PlayerInHouseState>());
    }
}
