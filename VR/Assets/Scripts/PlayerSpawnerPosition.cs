using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class PlayerSpawnerPosition : MonoBehaviour
{
    public Transform PosPlayerSpawn => transform;

    [SerializeField] private bool isVisiblePos;
    [SerializeField][Range(0f, 5f)] private float sizeGizmos;
    [SerializeField] private Color color;

    private void OnDrawGizmos()
    {
        if (isVisiblePos)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(PosPlayerSpawn.position, sizeGizmos);
        }
    }
}
