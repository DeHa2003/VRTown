using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] private Transform lopast;
    [SerializeField] private Vector3 vectorRotate;
    [SerializeField] private float speedRotate;

    public void Rotate()
    {
        lopast.Rotate(vectorRotate * Time.deltaTime * speedRotate);
    }
}
