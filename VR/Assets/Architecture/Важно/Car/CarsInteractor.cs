using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class CarsInteractor : Interactor, ICarsInteractorProvider, ICarsInteractorProvider_SetData
    {
        //public List<ICar> ActiveCars { get; private set; } = new List<ICar>();

        //private IWheel wheel;
        //private CarAI[] carAIsPrefabs;
        //public void SetData(CarAI[] carAIPrefabs, IWheel wheel)
        //{
        //    this.carAIsPrefabs = carAIPrefabs;
        //    this.wheel = wheel;
        //}

        //public void RandomSpawn()
        //{
        //    List<Transform> transforms;
        //    Transform posSpawn;

        //    wheel.GetRandomPath(out transforms, out posSpawn);

        //    ICar ICar = Coroutines.Instantiate(carAIsPrefabs[Random.Range(0, carAIsPrefabs.Length)], posSpawn.position, Quaternion.identity).GetComponent<ICar>();
        //    ICar.Initialize(transforms);
        //    ICar.SetSpeed(7);
        //    ICar.OnDestroyCarAction += () =>
        //    {
        //        ActiveCars.Remove(ICar);
        //    };
        //    ActiveCars.Add(ICar);
        //}

        //public void Spawn(CarAI carAI)
        //{
        //    //ICar car = Coroutines.Instantiate(carAI, posSpawns[Random.Range(0, posSpawns.Length)].position, Quaternion.identity).GetComponent<ICar>();
        //    //car.Initialize(wheel.GetRandomPath());
        //    //car.SetSpeed(7);
        //    //ActiveCars.Add(car);
        //}

        //public void StopAllCars()
        //{
        //    CleanList();

        //    for (int i = 0; i < ActiveCars.Count; i++)
        //    {
        //        ActiveCars[i].StopCar();
        //    }
        //}

        //public void ResumeAllCars()
        //{
        //    CleanList();

        //    for (int i = 0; i < ActiveCars.Count; i++)
        //    {
        //        ActiveCars[i].MoveCar();
        //    }
        //}

        //public void Destroy(CarAI carAI)
        //{
        //    ICar car = carAI.GetComponent<ICar>();
        //    ActiveCars.Remove(car);
        //    car.Destroy();
        //}

        //private void CleanList()
        //{
        //    ActiveCars.RemoveAll(Item => Item == null);
        //}
        private ICarSpawner[] carSpawners;

        public void SetData(ICarSpawner[] carSpawners)
        {
            this.carSpawners = carSpawners;
        }
        public void SpawnRandomCar()
        {
            int a = Random.Range(0, carSpawners.Length);
            carSpawners[a].CarSpawn_RandomPositionAndPrefab();
        }
    }
}

public interface ICarsInteractorProvider : IInterface
{
    void SpawnRandomCar();
}

//public interface ICarsInteractorsProvider : IInterface
//{
//    void RandomSpawn();
//    void Spawn(CarAI carAI);
//    void Destroy(CarAI carAI);
//    void StopAllCars();
//    void ResumeAllCars();
//}

public interface ICarsInteractorProvider_SetData : IInterface
{
    //void SetData(CarAI[] carAIPrefabs, IWheel wheel);
    void SetData(ICarSpawner[] carSpawners);
}
