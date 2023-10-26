using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class LaserController : MonoBehaviour
{
    [SerializeField] SteamVR_Action_Boolean Laser;
    [SerializeField] private List<GameObject> hands;

    private bool isActiveLaser = false;

    public void AddLaserPointer()
    {
        if (!hands[0].GetComponent<LaserScript>())
        {
            for (int i = 0; i < hands.Count; i++)
            {
                hands[i].AddComponent<LaserScript>();
            }
        }
    }

    public void RemoveLaserPointer()
    {
        if (hands[0].GetComponent<LaserScript>())
        {
            for (int i = 0; i < hands.Count; i++)
            {
                Destroy(hands[i].GetComponent<LaserScript>());
            }
        }
    }

    private void Update()
    {
        if (Laser.GetStateDown(SteamVR_Input_Sources.Any) && !isActiveLaser)
        {
            isActiveLaser = true;
            AddLaserPointer();
        }
        else if(Laser.GetStateDown(SteamVR_Input_Sources.Any) && isActiveLaser)
        {
            isActiveLaser=false;
            RemoveLaserPointer();
        }
    }
}
