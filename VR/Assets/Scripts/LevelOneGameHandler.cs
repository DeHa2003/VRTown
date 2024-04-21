using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneGameHandler : Handler
{
    private protected override void Awake()
    {
        base.Awake();
        Game.Run(new LevelOneSceneManager());
    }
}
