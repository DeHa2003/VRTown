using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private Drone_Animation animationScript;
    [SerializeField] private Drone_Move moveScript;
    
    public void Initialize()
    {
        animationScript.Initialize();
        moveScript.Initialize();
    }

    public void Activate()
    {
        animationScript.Activate();
    }

    public void Deactivate()
    {
        animationScript.Deactivate();
    }

    public void Move(Vector3 vector)
    {
        moveScript.Move(vector);
    }
}
