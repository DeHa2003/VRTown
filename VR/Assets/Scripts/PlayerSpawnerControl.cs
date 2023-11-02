using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Valve.VR.InteractionSystem;
public class PlayerSpawnerControl : PlayerComponentControl
{
    [SerializeField] private bool isVisiblePos;
    [SerializeField][Range(0f, 5f)] private float sizeGizmos;
    [SerializeField] private Color color;
    [SerializeField] private Transform posPlayerSpawn;

    private CharacterController characterController;
    private void Awake()
    {
        Debug.Log("Дочерний класс");
        characterController = getPlayer.player.GetComponent<CharacterController>();
        characterController.enabled = false;
        characterController.transform.position = posPlayerSpawn.position;
        characterController.enabled = true;
    }

    private void OnDrawGizmos()
    {
        if (isVisiblePos)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(posPlayerSpawn.position, sizeGizmos);
        }
    }
}
