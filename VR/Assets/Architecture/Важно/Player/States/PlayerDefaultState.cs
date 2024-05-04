using Lessons.Architecture;
using UnityEngine;

public class PlayerDefaultState : IPlayerState
{
    private IPlayerInteractorProvider playerInteractorProvider;

    public PlayerDefaultState()
    {
        playerInteractorProvider = Game.GetInterface<IPlayerInteractorProvider, PlayerInteractor>();
    }

    public void EnterState()
    {
        Debug.Log("Активация состояния - Обычный");

        playerInteractorProvider.GamePlayer.SetSpeedMove(3);
        playerInteractorProvider.GamePlayer.ActivateMoveController();
        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.ActivateLaserController();

        playerInteractorProvider.GamePlayer.SetMenuDefault();
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("Деактивация состояния - Обычный");

        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
        playerInteractorProvider.GamePlayer.DeactivateMoveController();
    }
}
