using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveLaserState : IPlayerState
{
    private PlayerInteractor playerInteractor;

    public PlayerActiveLaserState()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();
    }

    public void EnterState()
    {
        Debug.Log("��������� ��������� - �������� �����");
        playerInteractor.PlayerComponents.ActivateLaserControl();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - �������� �����");
        playerInteractor.PlayerComponents.DeactivateLaserControl();
    }
}
