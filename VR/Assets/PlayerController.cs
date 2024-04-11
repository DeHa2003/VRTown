using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField] protected PlayerSpawnerPosition playerSpawn;
    protected Dictionary<Type, IPlayerState> playerStates;
    protected IPlayerState playerCurrentState;

    protected PlayerInteractor playerInteractor;

    public override void InitializeController()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();
        InitializeStates();

        StartPlayer();
        SetStartState();
    }

    public virtual void StartPlayer()
    {
        playerInteractor.CreatePlayer();
        playerInteractor.PlayerToPosition(playerSpawn.PosPlayerSpawn.position);
    }

    public override void OnDestroyController()
    {
        if (playerCurrentState != null)
            playerCurrentState.ExitState();
    }

    protected virtual void InitializeStates()
    {
        playerStates = new Dictionary<Type, IPlayerState>();

        playerStates[typeof(PlayerDefaultState)] = new PlayerDefaultState();
        playerStates[typeof(PlayerActiveLaserState)] = new PlayerActiveLaserState();
        playerStates[typeof(PlayerFailedState)] = new PlayerFailedState();
    }

    protected virtual void SetStartState()
    {
        SetPlayerActiveLaserState();
    }

    public void SetPlayerFailedState()
    {
        SetState(GetState<PlayerFailedState>());
    }

    public void SetPlayerDefaultState()
    {
        SetState(GetState<PlayerDefaultState>());
    }

    public void SetPlayerActiveLaserState()
    {
        SetState(GetState<PlayerActiveLaserState>());
    }

    protected void SetState(IPlayerState playerState)
    {
        if (playerCurrentState != null)
            playerCurrentState.ExitState();

        playerCurrentState = playerState;
        playerCurrentState.EnterState();
    }

    protected IPlayerState GetState<T>() where T : IPlayerState
    {
        return playerStates[typeof(T)];
    }
}


