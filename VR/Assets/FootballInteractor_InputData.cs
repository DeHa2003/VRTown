using Lessons.Architecture;
using UnityEngine;

public class FootballInteractor_InputData : InputData
{
    [SerializeField] private FootballGoal goalA;
    [SerializeField] private FootballGoal goalB;
    [SerializeField] private FootballBall ball;
    [SerializeField] private Transform posSpawnBall;

    private IFootballInteractorProvider_SetData footballInteractorProvider_SetData;

    public override void Initialize()
    {
        footballInteractorProvider_SetData = Game.GetInterface<IFootballInteractorProvider_SetData, FootballInteractor>();
        footballInteractorProvider_SetData.SetData(goalA, goalB, ball, posSpawnBall);
    }
}
