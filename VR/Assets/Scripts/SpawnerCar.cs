using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnerCar : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private int limit;
    public List<GameObject> carsPref;
    public List<NavMeshAgent> agents;
    void Start()
    {
        CarSpawner();
    }

    private IEnumerator Spawner()
    {
        foreach (var s in agents)
        {
            if (s == null)
            {
                agents.Remove(s);
            }
        }

        if (agents.Count < limit)
        {
            agents.Add(Instantiate(carsPref[Random.Range(0, carsPref.Count)]).GetComponent<NavMeshAgent>());
        }

        yield return new WaitForSeconds(Random.Range(min, max));

        StartCoroutine(nameof(Spawner));
    }

    private void CarSpawner()
    {
        Instantiate(carsPref[Random.Range(0, carsPref.Count)]);
        Invoke(nameof(CarSpawner), Random.Range(min, max));
    }

    //public void RemoveFromList(NavMeshAgent meshAgent)
    //{
    //    agents.Remove(meshAgent);
    //}
}
