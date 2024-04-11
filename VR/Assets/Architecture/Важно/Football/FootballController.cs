using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : Controller
{
    [SerializeField] private FootballGoal footballGoalCommandA;
    [SerializeField] private FootballGoal footballGoalCommandB;

    [SerializeField] private FootballScoreVisualize scoreVisualize;

    public override void InitializeController()
    {
        base.InitializeController();
        scoreVisualize.Initalize();
        scoreVisualize.Activate();
    }

    public override void ActivateController()
    {
        base.ActivateController();
    }

    public override void DeactivateController()
    {
        base.DeactivateController();

        scoreVisualize.Deactivate();
    }

    public override void OnDestroyController()
    {
        base.OnDestroyController();

        DeactivateController();
    }
}
