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
        //playerInteractorProvider.GamePlayer.SetSpeedMove(0);

        playerInteractorProvider.GamePlayer.SetMenuData(TypeMenu.Successed);
        playerInteractorProvider.GamePlayer.InstantiateMenu();
    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - ������");

        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.ActivateMoveController();
        //playerInteractorProvider.GamePlayer.SetDefaultSpeedMove();
    }

    public void UpdateState()
    {

    }
}
