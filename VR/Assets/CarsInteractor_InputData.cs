using Lessons.Architecture;
using UnityEngine;

public class CarsInteractor_InputData : InputData
{
    [SerializeField] private TrafficSystemVehicleSpawner[] vehicleSpawners;

    private ICarsInteractorProvider_SetData carsInteractorProvider_SetData;
    public override void Initialize()
    {
        carsInteractorProvider_SetData = Game.GetInterface<ICarsInteractorProvider_SetData, CarsInteractor>();
        carsInteractorProvider_SetData.SetData(vehicleSpawners);
    }
}
