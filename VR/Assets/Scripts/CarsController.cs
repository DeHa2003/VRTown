using Lessons.Architecture;
using System.Collections;
using UnityEngine;

public class CarsController : Controller
{
    [SerializeField] private int minTimeSpawn;
    [SerializeField] private int maxTimeSpawn;

    private ICarsInteractorProvider carsInteractorProvider;
    private bool isActiveTraffic = false;
    private int time;

    public override void InitializeController()
    {
        base.InitializeController();

        carsInteractorProvider = Game.GetInterface<ICarsInteractorProvider, CarsInteractor>();
        StartSpawnCars();
    }

    public void StartSpawnCars()
    {
        StartCoroutine(StartSpawnCars_Coroutine());
    }

    public void StopSpawnCars()
    {
        isActiveTraffic = false;
    }

    private IEnumerator StartSpawnCars_Coroutine()
    {
        isActiveTraffic = true;
        while (isActiveTraffic)
        {
            time = Random.Range(minTimeSpawn, maxTimeSpawn);
            yield return new WaitForSeconds(time);
            carsInteractorProvider.SpawnRandomCar();
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        carsInteractorProvider.SpawnRandomCar();
    //    }

    //    //if (Input.GetKeyDown(KeyCode.LeftAlt))
    //    //{
    //    //    carsInteractorProvider.StopAllCars();
    //    //}

    //    //if (Input.GetKeyDown(KeyCode.RightAlt))
    //    //{
    //    //    carsInteractorProvider.ResumeAllCars();
    //    //}
    //}
}
