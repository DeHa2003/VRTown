using Lessons.Architecture;
using UnityEngine;

public class PlayerInteractor_InputData : InputData
{
    [SerializeField] private string targetName;

    private IPlayerEvents playerEvents;
    private IPlayerTransitionInteractorProvider_SetData playerTransitionInteractorProvider_SetData;

    private IPlayerInteractorProvider_SetData playerInteractorProvider_SetData;
    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();
        playerTransitionInteractorProvider_SetData = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();
        playerTransitionInteractorProvider_SetData.SetData(playerEvents);

        playerInteractorProvider_SetData = Game.GetInterface<IPlayerInteractorProvider_SetData, PlayerInteractor>();
        playerInteractorProvider_SetData.SetData(targetName);
    }
}
