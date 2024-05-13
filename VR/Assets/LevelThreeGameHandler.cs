using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeGameHandler : Handler
{
    private protected override void Awake()
    {
        base.Awake();
        Game.Run(new LevelThreeSceneManager());
    }
}
