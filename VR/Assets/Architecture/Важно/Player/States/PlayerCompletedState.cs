using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompletedState : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;

    public PlayerCompletedState()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
    }
    public void EnterState()
    {
        Debug.Log("��������� ��������� - ������");

        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.DeactivateMoveController();

        playerInteractorProvider.GamePlayer.SetMenuCompleted();
        playerInteractorProvider.GamePlayer.InstantiateMenu();
    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - ������");

        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.ActivateMoveController();
    }

    public void UpdateState()
    {

    }
}
