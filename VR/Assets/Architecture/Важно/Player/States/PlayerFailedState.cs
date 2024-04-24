using Lessons.Architecture;
using UnityEngine;

public class PlayerFailedState : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;
    public PlayerFailedState()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
    }
    public void EnterState()
    {
        Debug.Log("Активация состояния - Проигрыш");

        playerInteractorProvider.GamePlayer.ActivateLaserController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.SetSpeedMove(0);

        playerInteractorProvider.GamePlayer.SetMenuData(TypeMenu.Failed);
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
        playerInteractorProvider.GamePlayer.SetDefaultSpeedMove();
    }
}
