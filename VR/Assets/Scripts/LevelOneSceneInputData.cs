using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneInputData : InputData
{
    [SerializeField] private TrafficSystemVehicleSpawner[] vehicleSpawners;

    IPlayerEvents playerEvents;

    IPlayerTransitionInteractorProvider_SetData setDataTransitionInteractor;
    ICarsInteractorProvider_SetData carsInteractorProvider_SetData;
    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();

        setDataTransitionInteractor = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();
        carsInteractorProvider_SetData = Game.GetInterface<ICarsInteractorProvider_SetData, CarsInteractor>();

        setDataTransitionInteractor.SetData(playerEvents);
        carsInteractorProvider_SetData.SetData(vehicleSpawners);
    }
}
