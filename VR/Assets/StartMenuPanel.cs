using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuPanel : ColliderPanel
{
    private FadeScreenInteractor fadeScreenInteractor;

    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("666");
        fadeScreenInteractor = Game.GetInteractor<FadeScreenInteractor>();
    }


    public void StartGame()
    {
        fadeScreenInteractor.StartFadeToTransition(1, 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
