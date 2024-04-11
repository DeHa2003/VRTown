using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : Handler
{
    private protected override void Awake()
    {
        Game.Run(new MainSceneManager());
        base.Awake();
    }
}
