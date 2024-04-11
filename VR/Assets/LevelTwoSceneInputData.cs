using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSceneInputData : InputData
{
    [SerializeField] private FootballGoal goalA;
    [SerializeField] private FootballGoal goalB;
    //[SerializeField] private PanelsControl menuPref;
    //[SerializeField] private PlayerSpawnerPosition playerSpawn;

    //private PlayerInteractor playerInteractor;
    private FootballInteractor footballInteractor;
    public override void Initialize()
    {
        //playerInteractor = Game.GetInteractor<PlayerInteractor>();
        footballInteractor = Game.GetInteractor<FootballInteractor>();
        footballInteractor.SetData(goalA, goalB);

        //playerInteractor.CreatePlayer();
        //playerInteractor.PlayerToPosition(playerSpawn.PosPlayerSpawn.position);
        //playerInteractor.PlayerComponents.ActivateLaserControl();
        //playerInteractor.PlayerComponents.ActivateMenuControl(menuPref);
        footballInteractor.Activate();
    }
}
