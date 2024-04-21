using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneInputData : InputData
{
    private IPlayerEvents playerEvents;
    private IPlayerTransitionInteractorProvider_SetData setDataTransitionInteractor;

    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();
        setDataTransitionInteractor = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();

        setDataTransitionInteractor.SetData(playerEvents);
    }
}
