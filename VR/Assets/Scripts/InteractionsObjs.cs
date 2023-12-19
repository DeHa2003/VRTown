using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsObjs : MonoBehaviour
{
    private GameObject[] interactions;

    private void Start()
    {
        interactions = GameObject.FindGameObjectsWithTag("VR Item");
    }

    public void Parent()
    {
        if(interactions.Length == 0) { return; }
        for (int i = 0; i < interactions.Length; i++)
        {
           Destroy(interactions[i]);
        }
    }
}
