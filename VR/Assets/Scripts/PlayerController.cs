using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField] protected PlayerPosition playerSpawn;

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
        playerTransitionInteractorProvider.TransitionToPosition(playerSpawn.GetPlayerTransform.position);
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
        playerStates[typeof(PlayerFailedState_Wheel)] = new PlayerFailedState_Wheel();
        playerStates[typeof(PlayerFailedState_PedestrianCross)] = new PlayerFailedState_PedestrianCross();
    }

    protected virtual void SetStartState()
    {
        SetPlayerDefaultState();
    }

    public void SetPlayerFailedState_PedestrianCross()
    {
        SetState(GetState<PlayerFailedState_PedestrianCross>());
    }

    public void SetPlayerFailedState_Wheel()
    {
        SetState(GetState<PlayerFailedState_Wheel>());
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

    private void Update()
    {
        if(playerCurrentState != null)
           playerCurrentState.UpdateState();
    }
}


