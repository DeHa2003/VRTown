using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGameHandler : Handler
{
    [SerializeField] private InteractionsObjectsControl interactionsObjectsControl;

    private protected override void Awake()
    {
        base.Awake();
        Game.Run(new HouseSceneManager());
    }
    private protected override void OnGameInitialized()
    {
        base.OnGameInitialized();
        interactionsObjectsControl.Initialize();
    }
}
