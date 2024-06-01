using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestinateMenu_MainPanel : ScaleColliderPanel
{
    [SerializeField] protected TextMeshProUGUI destinateDescription;
    [SerializeField] protected TextMeshProUGUI typeOfViolationText;

    //protected GameObject PlayerControls { get; private set; }
    //protected GetTaskScene TaskManager { get; private set; }
    //protected SceneTransitionControl TransitionControl { get; private set; }

    private TransitionInteractor screenInteractor;

    public override void Initialize()
    {
        base.Initialize();

        screenInteractor = Game.GetInteractor<TransitionInteractor>();
        //PlayerControls = GameObject.FindGameObjectWithTag("PlayerControls");
        //TaskManager = PlayerControls.GetComponent<GetTaskScene>();
        //TransitionControl = PlayerControls.GetComponent<SceneTransitionControl>();
        //destinateDescription.text = TaskManager.GetTask();
    }

    public void SetDestinateDescription(string textDestinateDescription)
    {
        destinateDescription.text = textDestinateDescription;
    }

    public void SetTypeOfViolation(string typeViolation)
    {
        //typeOfViolationText.text = typeViolation;
    }

    public void Restart()
    {
        screenInteractor.TransitionToScene_Fade(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        screenInteractor.TransitionToScene_Fade(0);
    }
}
