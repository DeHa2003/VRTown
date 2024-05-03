using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Move : MonoBehaviour
{
    [SerializeField] private float speedMoveUp;
    [SerializeField] private float speedMoveDown;

    [SerializeField] private float gravitationValue;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed = 2;
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

    public void MoveUp(float value)
    {
        controller.Move(new Vector3(0, value, 0) * Time.deltaTime * speedMoveUp);
    }

    public void MoveDown(float value)
    {
        controller.Move(new Vector3(0, -value, 0) * Time.deltaTime * speedMoveDown);
    }

    public void Move(Vector3 vector)
    {
        Vector3 vectorDirection = transform.TransformDirection(vector) * Time.deltaTime * moveSpeed;
        controller.Move(vectorDirection);
    }

    public void SetGravitation(float gravitation)
    {
        gravitationValue = gravitation;
    }

    public void TeleportToPosition(Vector3 vector)
    {
        controller.enabled = false;

        transform.position = vector;

        controller.enabled = true;
    }

    public void Rotate(Vector2 vector)
    {
        //float rotateAmount = vector.y * rotateSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.up, rotateAmount);

        if(vector != Vector2.zero)
        {
            //Vector3 direction = new Vector3(vector.x, 0, vector.y);
            //Vector3 rotationVector = Quaternion.Euler(0, transform.eulerAngles.y, 0) * direction;
            //transform.rotation = Quaternion.LookRotation(rotationVector * Time.deltaTime * rotateSpeed);


            //Quaternion targetRotation = Quaternion.LookRotation(vector, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

            float rotateAmount = vector.x * rotateSpeed * Time.deltaTime; 
            transform.Rotate(0, rotateAmount, 0);
        }
    }

    private void Update()
    {
        controller.Move(new Vector3 (0, -9.31f, 0) * Time.deltaTime * gravitationValue);
    }
}
