using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerToRoad;
    public UnityEvent OnTriggerToZebra;
    public UnityEvent OnTriggerFinish;

    [SerializeField] private Transform posToSpawn;
    [SerializeField] private GameObject failedGameUI;
    [SerializeField] private GameObject completedGameUI;

    private string roadViolation = "Пешеходам запрещено пересекать проезжую часть вне пешеходного перехода";
    private string zebViolation = "Тест";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Road") || other.CompareTag("Zeb"))
        {

            GameObject failedPanel = Instantiate(failedGameUI, posToSpawn.position, posToSpawn.rotation);

            if (other.CompareTag("Road"))
            {
                failedPanel.GetComponentInChildren<PanelFailed>().SetTypeOfViolation(roadViolation);
                OnTriggerToRoad?.Invoke();
            }
            else if(other.CompareTag("Zeb"))
            {
                failedPanel.GetComponentInChildren<PanelFailed>().SetTypeOfViolation(zebViolation);
                OnTriggerToZebra?.Invoke();
            }
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish"))
        {
            Instantiate(completedGameUI, posToSpawn.position, posToSpawn.rotation);
            OnTriggerFinish?.Invoke();
            Time.timeScale = 0;
        }
    }
}
