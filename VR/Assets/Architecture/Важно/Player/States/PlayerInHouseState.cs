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

        playerInteractorProvider.GamePlayer.SetSpeedMove(2);
        playerInteractorProvider.GamePlayer.ActivateMoveController();
        playerInteractorProvider.GamePlayer.ActivateLaserController();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - � ����");

        playerInteractorProvider.GamePlayer.DeactivateMoveController();
        playerInteractorProvider.GamePlayer.DeactivateLaserController();
    }
}
