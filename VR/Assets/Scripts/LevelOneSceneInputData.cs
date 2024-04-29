using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneInputData : InputData
{
    [SerializeField] private Drone drone;
    [SerializeField] private TrafficSystemVehicleSpawner[] vehicleSpawners;

    private IPlayerEvents playerEvents;

    private IPlayerTransitionInteractorProvider_SetData setDataTransitionInteractor;
    private ICarsInteractorProvider_SetData carsInteractorProvider_SetData;
    private DroneInteractor droneInteractor;

    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();

        setDataTransitionInteractor = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();
        carsInteractorProvider_SetData = Game.GetInterface<ICarsInteractorProvider_SetData, CarsInteractor>();

        droneInteractor = Game.GetInteractor<DroneInteractor>();
        droneInteractor.SetData(drone);

        setDataTransitionInteractor.SetData(playerEvents);
        carsInteractorProvider_SetData.SetData(vehicleSpawners);
    }
}
