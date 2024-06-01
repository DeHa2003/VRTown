using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform m_CameraTransform;
    [SerializeField] private Vector3 vectorRotate;
    [SerializeField] private float speed;
    public bool isActive = false;

    void Update()
    {
        if (isActive && m_CameraTransform != null)
        {
            m_CameraTransform.Rotate(vectorRotate * Time.deltaTime * speed);
        }
    }
}
