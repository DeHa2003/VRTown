using Lessons.Architecture;
using UnityEngine;

public class PlayerFailedState_Wheel : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;
    public PlayerFailedState_Wheel()
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

        playerInteractorProvider.GamePlayer.SetMenuFailed_Wheel();
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
