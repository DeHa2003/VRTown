using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private bool isActive = true;

    public void ActivateCamera()
    {
        isActive = true;
        _camera.enabled = true;
    }

    public void DeactivateCamera()
    {
        isActive = false;
        _camera.enabled = false;
    }

    public void CheckCamera()
    {
        if(isActive)
        {
            DeactivateCamera();
        }
        else
        {
            ActivateCamera();
        }
    }
}
