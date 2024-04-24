using Lessons.Architecture;
using UnityEngine.SceneManagement;

public class DestinateCompletedPanel_MainPanel : ScaleColliderPanel
{
    private TransitionInteractor screenInteractor;

    public override void Initialize()
    {
        base.Initialize();

        screenInteractor = Game.GetInteractor<TransitionInteractor>();
    }

    public void Restart()
    {
        screenInteractor.TransitionToScene_Fade(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        screenInteractor.TransitionToScene_Fade(1);
    }
}
