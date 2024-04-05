using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : Handler
{
    [SerializeField] private GameInputData inputData;
    private protected override void Awake()
    {
        Game.Run(new MainSceneManager());
        base.Awake();
    }

    private protected override void OnGameInitialized()
    {
        inputData.Initialize();
        base.OnGameInitialized();
    }
}
