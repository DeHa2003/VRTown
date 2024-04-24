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
        Debug.Log("��������� ��������� - � ����");

        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.SetSpeedMove(0);

        playerInteractorProvider.GamePlayer.SetMenuData(TypeMenu.Failed);
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - � ����");
        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.SetDefaultSpeedMove();
    }
}
