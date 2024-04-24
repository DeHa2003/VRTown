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
        Debug.Log("��������� ��������� - �������");

        playerInteractorProvider.GamePlayer.ActivateMenuController();
        playerInteractorProvider.GamePlayer.ActivateLaserController();

        playerInteractorProvider.GamePlayer.SetMenuData(TypeMenu.Default);
    }

    public void UpdateState()
    {

    }

    public void ExitState()
    {
        Debug.Log("����������� ��������� - �������");

        playerInteractorProvider.GamePlayer.DeactivateLaserController();
        playerInteractorProvider.GamePlayer.DeactivateMenuController();
    }
}
