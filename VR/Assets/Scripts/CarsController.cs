using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : Controller
{
    private ICarsInteractorProvider carsInteractorProvider;

    public override void InitializeController()
    {
        base.InitializeController();

        carsInteractorProvider = Game.GetInterface<ICarsInteractorProvider, CarsInteractor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            carsInteractorProvider.SpawnRandomCar();
        }

        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    carsInteractorProvider.StopAllCars();
        //}

        //if (Input.GetKeyDown(KeyCode.RightAlt))
        //{
        //    carsInteractorProvider.ResumeAllCars();
        //}
    }
}
