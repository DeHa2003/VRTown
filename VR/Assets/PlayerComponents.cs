using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [SerializeField] private PlayerMoveScript moveScript;
    [SerializeField] private PlayerFeetScript feetScript;
    [SerializeField] private PlayerLaserController laserController;

    public void Initialize()
    {
        moveScript.Initialize();
        feetScript.Initialize();
        laserController.Initialize();
    }
}
