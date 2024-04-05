using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : Handler
{
    [SerializeField] private MenuInputData inputData;
    private protected override void Awake()
    {
        Game.Run(new StartSceneManager());
        base.Awake();
    }

    private protected override void OnGameInitialized()
    {
        inputData.Initialize();
        base.OnGameInitialized();
    }
}
