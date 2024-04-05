using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameHandler : Handler
{
    private protected override void Awake()
    {
        base.Awake();
        Game.Run(new StartSceneManager());
    }
}
