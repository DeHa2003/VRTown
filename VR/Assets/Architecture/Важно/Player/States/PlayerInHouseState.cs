using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInHouseState : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;
    public PlayerInHouseState()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
    }
    public void EnterState()
    {
        Debug.Log("Активация состояния - В доме");

        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - В доме");
        playerInteractorProvider.GamePlayer.DeactivateLaserController();
    }
}
