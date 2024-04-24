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

    protected IPlayerInteractorProvider playerInteractor;
    protected IPlayerTransitionInteractorProvider playerTransitionInteractorProvider;

    public override void InitializeController()
    {
        playerInteractor = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
        playerTransitionInteractorProvider = Game.GetInterface<IPlayerTransitionInteractorProvider, TransitionInteractor>();

        InitializeStates();

        StartPlayer();
        SetStartState();
    }

    public virtual void StartPlayer()
    {
        playerInteractor.CreatePlayer();
        playerTransitionInteractorProvider.FadeScreen(0.5f, new Color(0, 0, 0, 0));
        playerTransitionInteractorProvider.TransitionToPosition(playerSpawn.PosPlayerSpawn.position);
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
        playerStates[typeof(PlayerCompletedState)] = new PlayerCompletedState();
        //playerStates[typeof(PlayerActiveLaserState)] = new PlayerActiveLaserState();
        playerStates[typeof(PlayerFailedState)] = new PlayerFailedState();
    }

    protected virtual void SetStartState()
    {
        SetPlayerDefaultState();
    }

    public void SetPlayerFailedState()
    {
        SetState(GetState<PlayerFailedState>());
    }

    public void SetPlayerDefaultState()
    {
        SetState(GetState<PlayerDefaultState>());
    }

    public void SetPlayerCompletedState()
    {
        SetState(GetState<PlayerCompletedState>());
    }

    protected void SetState(IPlayerState playerState)
    {
        if(playerCurrentState == playerState) return;

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


