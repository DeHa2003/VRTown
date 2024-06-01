using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinateFailedMenu_MainPanel : ScaleColliderPanel
{
    //[SerializeField] protected TextMeshProUGUI destinateDescription;
    //[SerializeField] protected TextMeshProUGUI typeOfViolationText;

    private TransitionInteractor screenInteractor;

    public override void Initialize()
    {
        base.Initialize();

        screenInteractor = Game.GetInteractor<TransitionInteractor>();
    }

    //public void SetDestinateDescription(string textDestinateDescription)
    //{
    //    destinateDescription.text = textDestinateDescription;
    //}

    //public void SetTypeOfViolation(string typeViolation)
    //{
    //    typeOfViolationText.text = typeViolation;
    //}

    public void Restart()
    {
        screenInteractor.TransitionToScene_Fade(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        screenInteractor.TransitionToScene_Fade(0);
    }
}
