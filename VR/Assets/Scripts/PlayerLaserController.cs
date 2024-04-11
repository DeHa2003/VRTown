using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    [SerializeField] private List<GameObject> hands;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private HandButtons handButtons;

    private bool isActiveLaser = false;

    public void Initialize(HandButtons handButtons)
    {
        this.handButtons = handButtons;
        audioSource.clip = audioClip;
    }

    private void AddLaserPointer()
    {
        isActiveLaser = true;

        if (!hands[0].GetComponent<LaserScript>())
        {
            for (int i = 0; i < hands.Count; i++)
            {
                hands[i].AddComponent<LaserScript>();
            }
        }
    }

    private void RemoveLaserPointer()
    {
        isActiveLaser = false;

        if (hands[0].GetComponent<LaserScript>())
        {
            for (int i = 0; i < hands.Count; i++)
            {
                Destroy(hands[i].GetComponent<LaserScript>());
            }
        }
    }

    private void CheckLaserPointer()
    {
        audioSource.Play();

        if (isActiveLaser)
        {
            RemoveLaserPointer();
        }
        else
        {
            AddLaserPointer();
        }
    }

    public void ActivateLaserController() 
    {
        handButtons.AddActionToLeftHand(CheckLaserPointer);
    }

    public void DeactivateLaserController() 
    {
        handButtons.RemoveActionToLeftHand(CheckLaserPointer);
    }

}
