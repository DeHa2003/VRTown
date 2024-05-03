using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSceneInputData : InputData
{
    [SerializeField] private string targetName;
    [SerializeField] private FootballGoal goalA;
    [SerializeField] private FootballGoal goalB;
    [SerializeField] private FootballBall ball;
    [SerializeField] private Transform posSpawnBall;

    [SerializeField] private TrafficSystemVehicleSpawner[] vehicleSpawners;

    //[SerializeField] private CarAI[] cars;
    //[SerializeField] private Wheel wheel;

    private IPlayerEvents playerEvents;
    private IPlayerInteractorProvider_SetData playerInteractorProvider_SetData;
    private IPlayerTransitionInteractorProvider_SetData playerTransitionInteractorProvider_SetData;
    private IFootballInteractorProvider_SetData footballInteractorProvider_SetData;
    private ICarsInteractorProvider_SetData carsInteractorProvider_SetData;
    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();
        playerTransitionInteractorProvider_SetData = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();
        playerTransitionInteractorProvider_SetData.SetData(playerEvents);

        footballInteractorProvider_SetData = Game.GetInterface<IFootballInteractorProvider_SetData, FootballInteractor>();
        footballInteractorProvider_SetData.SetData(goalA, goalB, ball, posSpawnBall);

        carsInteractorProvider_SetData = Game.GetInterface<ICarsInteractorProvider_SetData, CarsInteractor>();
        carsInteractorProvider_SetData.SetData(vehicleSpawners);

        playerInteractorProvider_SetData = Game.GetInterface<IPlayerInteractorProvider_SetData, PlayerInteractor>();
        playerInteractorProvider_SetData.SetData(targetName);
    }
}
