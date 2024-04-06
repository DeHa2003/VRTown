using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneInputData : InputData
{
    [SerializeField] private PlayerSpawnerPosition spawnerPosition;

    private PlayerInteractor playerInteractor;
    public override void Initialize()
    {
        base.Initialize();

        playerInteractor = Game.GetInteractor<PlayerInteractor>();

        playerInteractor.CreatePlayer();
        playerInteractor.PlayerToPosition(spawnerPosition.PosPlayerSpawn.position);
    }
}
