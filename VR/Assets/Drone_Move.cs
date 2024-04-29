using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Move : MonoBehaviour
{
    [SerializeField] private float gravitationValue;
    [SerializeField] private CharacterController controller;

    private float defaultGravitation;

    public void Initialize()
    {
        defaultGravitation = gravitationValue;
    }

    public void SetDefaultGravitation()
    {
        gravitationValue = defaultGravitation;
    }

    public void Move(Vector3 vector)
    {
        controller.Move(vector);
    }

    public void SetGravitation(float gravitation)
    {
        gravitationValue = gravitation;
    }

    private void Update()
    {
        controller.Move(new Vector3 (0, -9.31f, 0) * Time.deltaTime * gravitationValue);
    }
}
