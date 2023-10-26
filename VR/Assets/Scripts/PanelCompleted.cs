using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PanelCompleted : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI task;
    [SerializeField] private TextMeshProUGUI typeOfViolationText;
    private GameObject sceneManager;
    private PlayerComponents playerController;
    private TaskManager taskManager;

    private void Awake()
    {
        sceneManager = GameObject.FindWithTag("SceneManager");
        playerController = sceneManager.GetComponent<PlayerComponents>();
        playerController.AddLaserController(true);
        playerController.ActivateLaser(true);
        taskManager = sceneManager.GetComponent<TaskManager>();
        task.text = taskManager.GetTask();
    }
    public void SetTypeOfViolation(string typeViolation)
    {
        typeOfViolationText.text = typeViolation;
    }

    public void NextLevel()
    {
        // UPD.
    }

    public void GoToHome()
    {
        playerController.LoadScene(0);
    }
}
