using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField] private PlayerSpawnerPosition playerSpawn;
    private Dictionary<Type, IPlayerState> playerStates;
    private IPlayerState playerCurrentState;

    private PlayerInteractor playerInteractor;

    public override void InitializeController()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();
        playerInteractor.CreatePlayer();
        playerInteractor.PlayerToPosition(playerSpawn.PosPlayerSpawn.position);

        InitializeStates();
        SetPlayerActiveLaserState();
    }

    private void InitializeStates()
    {
        playerStates = new Dictionary<Type, IPlayerState>();

        playerStates[typeof(PlayerDefaultState)] = new PlayerDefaultState();
        playerStates[typeof(PlayerActiveLaserState)] = new PlayerActiveLaserState();
    }

    public void SetPlayerDefaultState()
    {
        SetState(GetState<PlayerDefaultState>());
    }

    public void SetPlayerActiveLaserState()
    {
        SetState(GetState<PlayerActiveLaserState>());
    }

    private void SetState(IPlayerState playerState)
    {
        if (playerCurrentState != null)
            playerCurrentState.ExitState();

        playerCurrentState = playerState;
        playerCurrentState.EnterState();
    }

    private IPlayerState GetState<T>() where T : IPlayerState
    {
        return playerStates[typeof(T)];
    }
}


