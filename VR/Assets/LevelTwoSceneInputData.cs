using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSceneInputData : InputData
{
    [SerializeField] private FootballGoal goalA;
    [SerializeField] private FootballGoal goalB;

    //private FootballInteractor footballInteractor;

    private ISetDataFootballInteractor setDataFootballInteractor;
    public override void Initialize()
    {
        setDataFootballInteractor = Game.GetInterface<ISetDataFootballInteractor, FootballInteractor>();
        setDataFootballInteractor.SetData(goalA, goalB);
        //footballInteractor.Activate();
    }
}
