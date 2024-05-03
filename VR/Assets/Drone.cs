using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drone : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    [SerializeField] private Drone_Animation animationScript;
    [SerializeField] private Drone_Move moveScript;
    [SerializeField] private Camera camera;
    
    public void Initialize()
    {
        animationScript.Initialize();
        moveScript.Initialize();
    }

    public void Activate()
    {
        OnActivate?.Invoke();
        animationScript.Activate();
        camera.enabled = true;
    }

    public void Deactivate()
    {
        OnDeactivate?.Invoke();
        animationScript.Deactivate();
        camera.enabled = false;
    }

    public void MoveUp(float value)
    {
        moveScript.MoveUp(value);
    }

    public void TeleportToPosition(Vector3 position)
    {
        moveScript.TeleportToPosition(position);
    }

    public void MoveDown(float value)
    {
        moveScript.MoveDown(value);
    }

    public void Move(Vector3 vector)
    {
        moveScript.Move(vector);
    }

    public void Rotate(Vector2 vector)
    {
        moveScript.Rotate(vector);
    }
}
