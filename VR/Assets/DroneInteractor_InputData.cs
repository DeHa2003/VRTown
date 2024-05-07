using Lessons.Architecture;
using UnityEngine;

public class DroneInteractor_InputData : InputData
{
    [SerializeField] private Drone drone;
    [SerializeField] protected Transform posSpawn;
    private DroneInteractor droneInteractor;
    public override void Initialize()
    {
        droneInteractor = Game.GetInteractor<DroneInteractor>();
        droneInteractor.SetData(drone, posSpawn);
    }
}
