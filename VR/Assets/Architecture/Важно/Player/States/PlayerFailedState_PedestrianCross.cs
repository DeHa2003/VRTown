using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFailedState_PedestrianCross : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;
    public PlayerFailedState_PedestrianCross()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
    }
    public void EnterState()
    {
        Debug.Log("Активация состояния - Проигрыш");

        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.DeactivateMoveController();
        //playerInteractorProvider.GamePlayer.SetSpeedMove(0);

        playerInteractorProvider.GamePlayer.SetMenuFailed_PedestrianCrossing();
        playerInteractorProvider.GamePlayer.InstantiateMenu();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - Проигрыш");
        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.ActivateMoveController();
        //playerInteractorProvider.GamePlayer.SetDefaultSpeedMove();
    }
}
