using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WheelRoads
{
    public bool ShowGizmos = true;
    public List<Transform> wheel;
    public Transform posSpawn;
    public Color colorGizmos;
}

public class Wheel : MonoBehaviour
{
    [SerializeField] private List<WheelRoads> wheelRoads;

    private Vector3 sizeCubeGizmos = new Vector3(2, 2, 2);

    public static Wheel instance;
    private void Awake()
    {
        instance = this;
    }

    public void StartPlay(out List<Transform> wheel, out Transform posStart)
    {
        int a = Random.Range(0, wheelRoads.Count);
        wheel = wheelRoads[a].wheel;
        posStart = wheelRoads[a].posSpawn;

    }

    private void OnDrawGizmos()
    {
        if (wheelRoads != null)
        {
            for (int i = 0; i < wheelRoads.Count; i++)
            {
                for (int q = 0; q < wheelRoads[i].wheel.Count; q++)
                {
                    if (wheelRoads[i].ShowGizmos)
                    {
                        Gizmos.color = wheelRoads[i].colorGizmos;
                        Gizmos.DrawWireSphere(wheelRoads[i].wheel[q].position, 2f);
                        Gizmos.DrawWireCube(wheelRoads[i].posSpawn.position, sizeCubeGizmos);
                    }
                }
            }
        }
    }
}
