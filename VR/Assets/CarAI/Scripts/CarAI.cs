using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CarAI : MonoBehaviour, ICar
{
    [Header("Car position")]
    [SerializeField] private Transform carPosition;
    [SerializeField] private GameObject carTarget;

    private Vector3 PositionToFollow = Vector3.zero;

    private List<Transform> waypoints = new List<Transform>();

    private float currentSpeed;
    private int currentWayPoint;

    private NavMeshAgent agent;

    public event Action OnCreateCarAction;
    public event Action OnDestroyCarAction;

    public void Initialize(List<Transform> waypoints)
    {
        OnCreateCarAction?.Invoke();
        agent = GetComponent<NavMeshAgent>();
        this.waypoints = waypoints;
        currentWayPoint = 0;
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
        agent.speed = currentSpeed;
    }

    public void StopCar()
    {
        agent.speed = 0;
    }

    public void MoveCar()
    {
        agent.speed = currentSpeed;
    }

    public void Destroy()
    {
        OnDestroyCarAction.Invoke();
        Destroy(this.gameObject);
    }

    //IEnumerator Start() 
    //{
    //    currentWayPoint = 0;
    //    yield return new WaitForSeconds(3);
    //    carTarget.tag = "CarAI";
    //    gameObject.tag = "CarAI";
    //}

    void FixedUpdate()
    {
        agent.SetDestination(PositionToFollow);
        PathProgress();
    }

    private void PathProgress()
    {
        agent.SetDestination(PositionToFollow);

        wayPointManager();

        void wayPointManager()
        {
            if (currentWayPoint >= waypoints.Count)
            {
                Destroy();
            }
            else
            {
                PositionToFollow = waypoints[currentWayPoint].position;

                if (PositionToFollow != null && carPosition!=null)
                {
                    if (Vector3.Distance(carPosition.position, PositionToFollow) < 2f)
                        currentWayPoint++;
                }
            }
        }
    }
}

public interface ICar
{
    event Action OnCreateCarAction;
    event Action OnDestroyCarAction;
    void Initialize(List<Transform> path);
    void SetSpeed(float speed);
    void MoveCar();
    void StopCar();
    void Destroy();
}
