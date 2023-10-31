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
    [SerializeField] private GameObject failedGameUI;
    [SerializeField] private GameObject completedGameUI;

    private string roadViolation = "��������� ��������� ���������� �������� ����� ��� ����������� ��������";
    private string zebViolation = "��������� ��������� ���������� �� ����������� �������� �� ������� ������ ����������� ���������";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Road") || other.CompareTag("Zeb"))
        {

            GameObject failedPanel = Instantiate(failedGameUI, posToSpawn.position, posToSpawn.rotation);

            if (other.CompareTag("Road"))
            {
                failedPanel.GetComponentInChildren<PanelFailed>().SetTypeOfViolation(roadViolation);
            }
            else if(other.CompareTag("Zeb"))
            {
                failedPanel.GetComponentInChildren<PanelFailed>().SetTypeOfViolation(zebViolation);
            }
            OnLoseGame?.Invoke();
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish"))
        {
            Instantiate(completedGameUI, posToSpawn.position, posToSpawn.rotation);
            AudioManager.instance.Play(Sound.TypeAudioSource.CompletedGame);
            OnCompletedGame?.Invoke();

            Time.timeScale = 0;
        }
    }
}
