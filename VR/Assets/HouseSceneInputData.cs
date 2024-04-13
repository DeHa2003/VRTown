using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSceneInputData : InputData
{
    [SerializeField] private PlayerSpawnerPosition playerSpawn;

    private PlayerInteractor playerInteractor;
    private TransitionInteractor fadeScreenInteractor;
    public override void Initialize()
    {
        playerInteractor = Game.GetInteractor<PlayerInteractor>();

        playerInteractor.CreatePlayer();
        fadeScreenInteractor.TransitionToPosition(playerSpawn.PosPlayerSpawn.position);
        //playerInteractor.PlayerToPosition(playerSpawn.PosPlayerSpawn.position);
        playerInteractor.GamePlayer.ActivateLaserController();
    }
}
