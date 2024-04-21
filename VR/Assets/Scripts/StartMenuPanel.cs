using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuPanel : ColliderPanel
{
    private TransitionInteractor fadeScreenInteractor;

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("666");
        fadeScreenInteractor = Game.GetInteractor<TransitionInteractor>();
    }


    public void StartGame()
    {
        fadeScreenInteractor.TransitionToScene_Fade(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
