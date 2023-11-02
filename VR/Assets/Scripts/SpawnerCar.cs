using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerCar : MonoBehaviour
{
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private List<GameObject> carsPref;
    void Start()
    {
        CarSpawner();
    }

    private void CarSpawner()
    {
        Instantiate(carsPref[Random.Range(0, carsPref.Count)]);
        Invoke(nameof(CarSpawner), Random.Range(min, max));
    }
}
