using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGameHandler : Handler
{
    private protected override void Awake()
    {
        base.Awake();
        Game.Run(new HouseSceneManager());
    }
}
