using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnerCar : MonoBehaviour
{
    public float min;
    public float max;
    [SerializeField] private List<GameObject> cars;
    void Start()
    {
        Spawner();
    }

    private void Spawner()
    {
        //Instantiate(cars[Random.Range(0, cars.Count)]).GetComponent<NavMeshAgent>();
        Instantiate(cars[Random.Range(0, cars.Count)]);
        Invoke(nameof(Spawner), Random.Range(min, max));
    }
}
