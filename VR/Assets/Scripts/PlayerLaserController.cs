using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{
    [SerializeField] private List<GameObject> hands;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private bool isActiveLaser = false;

    public void Initialize()
    {
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

    public void CheckLaserPointer()
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

}
