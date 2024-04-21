using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : Controller
{
    [SerializeField] private Obstacle[] obstacles;
    public override void InitializeController()
    {
        base.InitializeController();
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].Initialize();
        }
    }

    public override void ActivateController()
    {
        base.ActivateController();
    }

    public override void DeactivateController()
    {
        base.DeactivateController();
    }

    public override void OnDestroyController()
    {
        base.OnDestroyController();
    }
}
