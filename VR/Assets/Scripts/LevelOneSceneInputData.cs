using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneInputData : InputData
{
    [SerializeField] private string targetName;
    [SerializeField] private Drone drone;
    [SerializeField] private Transform posSpawnDrone;
    [SerializeField] private TrafficSystemVehicleSpawner[] vehicleSpawners;

    private IPlayerEvents playerEvents;

    private IPlayerInteractorProvider_SetData playerInteractorProvider_SetData;
    private IPlayerTransitionInteractorProvider_SetData setDataTransitionInteractor;
    private ICarsInteractorProvider_SetData carsInteractorProvider_SetData;
    private DroneInteractor droneInteractor;

    public override void Initialize()
    {
        playerEvents = Game.GetInterface<IPlayerEvents, PlayerInteractor>();
        setDataTransitionInteractor = Game.GetInterface<IPlayerTransitionInteractorProvider_SetData, TransitionInteractor>();
        setDataTransitionInteractor.SetData(playerEvents);


        carsInteractorProvider_SetData = Game.GetInterface<ICarsInteractorProvider_SetData, CarsInteractor>();
        carsInteractorProvider_SetData.SetData(vehicleSpawners);

        droneInteractor = Game.GetInteractor<DroneInteractor>();
        droneInteractor.SetData(drone, posSpawnDrone);

        playerInteractorProvider_SetData = Game.GetInterface<IPlayerInteractorProvider_SetData, PlayerInteractor>();
        playerInteractorProvider_SetData.SetData(targetName);
    }
}
