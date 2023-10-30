using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI task;
    [SerializeField] protected TextMeshProUGUI typeOfViolationText;
    protected GameObject sceneManager;
    protected PlayerComponents playerController;
    protected TaskManager taskManager;

    protected void Awake()
    {
        sceneManager = GameObject.FindWithTag("SceneManager");
        playerController = sceneManager.GetComponent<PlayerComponents>();
        taskManager = sceneManager.GetComponent<TaskManager>();
    }
    protected void Start()
    {
        task.text = taskManager.GetTask();

        playerController.AddLaserController(true);
        playerController.ActivateLaser(true);
    }
    public void SetTypeOfViolation(string typeViolation)
    {
        typeOfViolationText.text = typeViolation;
    }

    public void Restart()
    {
        playerController.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        playerController.LoadScene(0);
    }
}
