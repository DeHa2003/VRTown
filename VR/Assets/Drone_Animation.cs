using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Animation : MonoBehaviour
{
    [SerializeField] private Vector3 rotate;
    [SerializeField] private float speedRotate;
    [SerializeField] private Transform[] planes;

    private bool isActive = false;

    public void Initialize()
    {
        
    }

    public void Activate()
    {
        isActive = true;
        StartCoroutine(ActivateDrone_Coroutine());
    }

    public void Deactivate()
    {
        isActive = false;
    }

    private IEnumerator ActivateDrone_Coroutine()
    {
        while (isActive)
        {
            yield return null;

            for (int i = 0; i < planes.Length; i++)
            {
                planes[i].Rotate(rotate * Time.deltaTime * speedRotate);
            }
        }
    }
}
