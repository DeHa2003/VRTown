using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class WheelObstacle : Obstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Player>())
        {
            playerController.SetPlayerFailedState();
        }
    }
}
