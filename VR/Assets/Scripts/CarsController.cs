using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : Controller
{
    private ICarsInteractorsProvider carsInteractorProvider;

    public override void InitializeController()
    {
        base.InitializeController();

        carsInteractorProvider = Game.GetInterface<ICarsInteractorsProvider, CarsInteractor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            carsInteractorProvider.RandomSpawn();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            carsInteractorProvider.StopAllCars();
        }

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            carsInteractorProvider.ResumeAllCars();
        }
    }
}
