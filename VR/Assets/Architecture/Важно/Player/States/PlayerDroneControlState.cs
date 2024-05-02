using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneControlState : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;
    private DroneInteractor droneInteractor;

    private Vector2 vectorMove;
    private Vector2 vectorRotate;
    private float axisUp;
    private float axisDown;
    public PlayerDroneControlState()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
        droneInteractor = Game.GetInteractor<DroneInteractor>();
    }
    public void EnterState()
    {
        Debug.Log("��������� ��������� - ������ �����");

        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.DeactivateMoveController();

        droneInteractor.ActivateDrone();
        //playerInteractorProvider.GamePlayer.AddActionToUpperButton_LeftHand(playerInteractorProvider.GamePlayer.CheckCameraActivate);
    }

    public void UpdateState()
    {
        vectorMove = playerInteractorProvider.GamePlayer.GetDataLeftTouchpad();
        if(vectorMove != null )
           droneInteractor.Drone.Move(new Vector3(vectorMove.x, 0, vectorMove.y));

        vectorRotate = playerInteractorProvider.GamePlayer.GetDataRightTouchpad();
        if( vectorRotate != null )
            droneInteractor.Drone.Rotate(vectorRotate);

        axisUp = playerInteractorProvider.GamePlayer.GetDataLeftSqueeze();
        if(axisUp != 0)
           droneInteractor.Drone.MoveUp(axisUp);

        axisDown = playerInteractorProvider.GamePlayer.GetDataRightSqueeze();
        if(axisDown != 0)
           droneInteractor.Drone.MoveDown(axisDown);


    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - ������ �����");

        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.ActivateMoveController();

        //playerInteractorProvider.GamePlayer.RemoveActionToUpperButton_LeftHand(playerInteractorProvider.GamePlayer.CheckCameraActivate);

        droneInteractor.DeactivateDrone();
    }
}
