using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private List<GameObject> hands;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audio;

    private bool isActiveLaser = false;
    private void Awake()
    {
        audio.clip = audioClip;
    }

    private void OnEnable()
    {
        HandButtons.OnClickLeftHandMenu += CheckLaserPointer;
    }

    private void OnDisable()
    {
        HandButtons.OnClickLeftHandMenu -= CheckLaserPointer;
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
        audio.Play();

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
