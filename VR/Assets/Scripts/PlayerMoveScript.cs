using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float jumpGravity = -9.81f;
    public float gravity;

    [SerializeField] private SteamVR_Action_Vector2 touchpad;
    [SerializeField] private SteamVR_Action_Boolean jump;

    private Vector3 vectorToJump;
    private CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Vector3 vector = Player.instance.hmdTransform.TransformDirection(new Vector3(touchpad.axis.x, 0, touchpad.axis.y));
        characterController.Move(Vector3.ProjectOnPlane(Time.deltaTime * speed * vector, Vector3.up) - new Vector3(0, gravity *1.1f, 0) * Time.deltaTime);

        if(jump.GetStateDown(SteamVR_Input_Sources.Any) && characterController.isGrounded)
        {
            Jumping();
        }

    }

    private void Jumping()
    {
        vectorToJump.y = Mathf.Sqrt(jumpHeight * -3f * jumpGravity);
        characterController.Move(vectorToJump * Time.deltaTime * 100);
    }
}
