using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : Controller
{
    [SerializeField] private FootballScoreVisualize scoreVisualize;

    private IFootballInteractorProvider footballInteractorProvider;

    public override void InitializeController()
    {
        base.InitializeController();

        footballInteractorProvider = Game.GetInterface<IFootballInteractorProvider, FootballInteractor>();

        scoreVisualize.Initalize();
        scoreVisualize.Activate();
        ActivateController();
        
    }

    public override void ActivateController()
    {
        base.ActivateController();

        footballInteractorProvider.ActivateGame();
        footballInteractorProvider.SpawnFootballBall();
    }

    public override void DeactivateController()
    {
        base.DeactivateController();

        scoreVisualize.Deactivate();

        footballInteractorProvider.DeactivateGame();
    }

    public override void OnDestroyController()
    {
        base.OnDestroyController();

        DeactivateController();
    }
}
