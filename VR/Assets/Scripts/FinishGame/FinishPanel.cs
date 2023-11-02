using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI task;
    [SerializeField] protected TextMeshProUGUI typeOfViolationText;

    protected GameObject PlayerControls { get; private set; }
    protected LaserControl LaserControl { get; private set; }
    protected GetTaskScene TaskManager { get; private set; }
    protected SceneTransitionControl TransitionControl { get; private set; }

    private void Awake()
    {
        PlayerControls = GameObject.FindGameObjectWithTag("PlayerControls");
        LaserControl = PlayerControls.GetComponent<LaserControl>();
        TaskManager = PlayerControls.GetComponent<GetTaskScene>();
        TransitionControl = PlayerControls.GetComponent<SceneTransitionControl>();
    }

    protected void Start()
    {
        task.text = TaskManager.GetTask();
        LaserControl.ActivateComponent(true);
    }
    public void SetTypeOfViolation(string typeViolation)
    {
        typeOfViolationText.text = typeViolation;
    }

    public void Restart()
    {
        TransitionControl.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        TransitionControl.LoadScene(0);
    }
}
