using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneInputData : InputData
{
    [SerializeField] private PanelsControl menu;
    [SerializeField] private PlayerSpawnerPosition playerSpawn;

    private PlayerInteractor playerInteractor;
    public override void Initialize()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();

        playerInteractor.CreatePlayer();
        playerInteractor.PlayerToPosition(playerSpawn.PosPlayerSpawn.position);
        playerInteractor.PlayerComponents.ActivateLaserControl();
        //playerInteractor.PlayerComponents.ActivateMenuControl(menu);
    }
}
