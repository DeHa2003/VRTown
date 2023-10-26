using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    [SerializeField] private bool ShowGizmos;
    [SerializeField] private List<Transform> wheel1;
    [SerializeField] private Transform posSpawn1;
    [Space]
    [SerializeField] private List<Transform> wheel2;
    [SerializeField] private Transform posSpawn2;
    [Space]
    [SerializeField] private List<Transform> wheel3;
    [SerializeField] private Transform posSpawn3;
    [Space]
    [SerializeField] private List<Transform> wheel4;
    [SerializeField] private Transform posSpawn4;
    [Space]
    [SerializeField] private List<Transform> wheel5;
    [SerializeField] private Transform posSpawn5;
    [Space]
    [SerializeField] private List<Transform> wheel6;
    [SerializeField] private Transform posSpawn6;

    private List<List<Transform>> wheels = new List<List<Transform>>();
    private List<Transform> posSpawns = new List<Transform>();
    private void Awake()
    {
        wheels.Add(wheel1);
        wheels.Add(wheel2);
        wheels.Add(wheel3);
        wheels.Add(wheel4);
        wheels.Add(wheel5);
        wheels.Add(wheel6);

        posSpawns.Add(posSpawn1);
        posSpawns.Add(posSpawn2);
        posSpawns.Add(posSpawn3);
        posSpawns.Add(posSpawn4);
        posSpawns.Add(posSpawn5);
        posSpawns.Add(posSpawn6);
    }

    public void StartPlay(out List<Transform> wheel, out Transform posStart)
    {
        int a = Random.Range(0, wheels.Count);
        wheel = wheels[a];
        posStart = posSpawns[a];

    }

    private void OnDrawGizmos()
    {
        if (ShowGizmos == true && wheel1 != null)
        {
            for (int i = 0; i < wheel1.Count; i++)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(wheel1[i].position, 2f);
            }

            for (int i = 0; i < wheel2.Count; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(wheel2[i].position, 2f);
            }

            for (int i = 0; i < wheel3.Count; i++)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(wheel3[i].position, 2f);
            }

            for (int i = 0; i < wheel4.Count; i++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(wheel4[i].position, 2f);
            }

            for (int i = 0; i < wheel5.Count; i++)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(wheel5[i].position, 2f);
            }

            for (int i = 0; i < wheel6.Count; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(wheel6[i].position, 2f);
            }
        }
    }
}
