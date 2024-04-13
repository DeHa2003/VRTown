using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSceneInputData : InputData
{
    [SerializeField] private FootballGoal goalA;
    [SerializeField] private FootballGoal goalB;

    private IPlayerEvents playerEvents;

    private IPlayerTransitionInteractorProvider_SetData playerTransitionInteractorProvider_SetData;
    private IFootballInteractorProvider_SetData footballInteractorProvider_SetData;
    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();
        playerTransitionInteractorProvider_SetData = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();
        footballInteractorProvider_SetData = Game.GetInterface<IFootballInteractorProvider_SetData, FootballInteractor>();

        playerTransitionInteractorProvider_SetData.SetData(playerEvents);
        footballInteractorProvider_SetData.SetData(goalA, goalB);
    }
}
