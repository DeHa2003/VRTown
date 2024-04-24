using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public static Action OnLoseGame;
    public static Action OnCompletedGame;

    [SerializeField] private Transform posToSpawn;
    [SerializeField] private ScaleColliderPanel failedGameUI;
    [SerializeField] private ScaleColliderPanel completedGameUI;

    private string roadViolation = "Пешеходам запрещено пересекать проезжую часть вне пешеходного перехода";
    private string zebViolation = "Пешеходам запрещено переходить по пешеходному переходу на красный сигнал пешеходного светофора";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Road") || other.CompareTag("Zeb"))
        {
            OnLoseGame?.Invoke();

            ScaleColliderPanel failedPanel = Instantiate(failedGameUI, posToSpawn.position, posToSpawn.rotation);
            failedPanel.OpenPanel();

            if (other.CompareTag("Road"))
            {
                //failedPanel.GetComponentInChildren<PanelFailed>().SetTypeOfViolation(roadViolation);
            }
            else if(other.CompareTag("Zeb"))
            {
                //failedPanel.GetComponentInChildren<PanelFailed>().SetTypeOfViolation(zebViolation);
            }

            AudioManager_del.instance.Play(Sound.TypeAudioSource.LoseGame);
        }
        else if (other.CompareTag("Finish"))
        {
            OnCompletedGame?.Invoke();
            ScaleColliderPanel completedPanel = Instantiate(completedGameUI, posToSpawn.position, posToSpawn.rotation);
            completedPanel.OpenPanel();
            AudioManager_del.instance.Play(Sound.TypeAudioSource.CompletedGame);
        }
    }
}
