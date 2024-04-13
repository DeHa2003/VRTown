using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFailedState : IPlayerState
{
    private PlayerInteractor playerInteractor;

    public PlayerFailedState()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();
    }
    public void EnterState()
    {
        Debug.Log("Активация состояния - Проигрыш");
        playerInteractor.GamePlayer.SetSpeedMove(0);
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        playerInteractor.GamePlayer.SetDefaultSpeedMove();
        Debug.Log("Деактивация состояния - Проигрыш");
    }
}
