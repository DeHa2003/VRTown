using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartPanelMenu : MonoBehaviour
{
    [SerializeField] private List<BoxCollider> buttonsColliders;
    [SerializeField] private TextMeshProUGUI textTask;
    private GameObject sceneManager;
    private PlayerComponents playerController;
    private TaskManager taskManager;

    private void Awake()
    {
        sceneManager = GameObject.FindWithTag("SceneManager");
        playerController = sceneManager.GetComponent<PlayerComponents>();
        taskManager = sceneManager.GetComponent<TaskManager>();
        textTask.text = taskManager.GetTask();

    }

    private void OnEnable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = true;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = false;
        }
    }

    public void OpenPanel(GameObject panel)
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
    }
    
    public void CloseMenu()
    {
        playerController.ActivateLaser(false);
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void GoToHome()
    {
        playerController.LoadScene(0);
    }
}
