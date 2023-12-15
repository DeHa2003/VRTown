using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerCar : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private List<GameObject> carsPref;
    void Start()
    {
        CarSpawner();
    }

    private void CarSpawner()
    {
        virtualCamera.LookAt = Instantiate(carsPref[Random.Range(0, carsPref.Count)]).transform;
        Invoke(nameof(CarSpawner), Random.Range(min, max));
    }
}
