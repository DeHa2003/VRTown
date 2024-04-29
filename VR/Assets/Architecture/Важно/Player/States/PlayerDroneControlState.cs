using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneControlState : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;
    private DroneInteractor droneInteractor;
    private Vector2 vector;
    public PlayerDroneControlState()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
        droneInteractor = Game.GetInteractor<DroneInteractor>();
    }
    public void EnterState()
    {
        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.SetSpeedMove(0);

        droneInteractor.ActivateDrone();
    }

    public void UpdateState()
    {
        vector = (playerInteractorProvider.GamePlayer.GetDataLeftTouchpad());
        droneInteractor.Drone.Move(new Vector3(vector.x, 0, vector.y) * Time.deltaTime * 3);
    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - Проигрыш");
        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.SetDefaultSpeedMove();

        droneInteractor.DeactivateDrone();
    }
}
