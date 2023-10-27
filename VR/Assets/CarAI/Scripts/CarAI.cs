using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random = UnityEngine.Random;

public class CarAI : MonoBehaviour
{
    [Header("Car position")]
    [SerializeField] private Transform carPosition;
    [SerializeField] private GameObject carTarget;

    private Vector3 PositionToFollow = Vector3.zero;
    private int currentWayPoint;
    private List<Transform> waypoints = new List<Transform>();
    private NavMeshAgent agent;
    private Transform posStart;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(7, 12);
    }

    IEnumerator Start() 
    {
        GetPath();
        currentWayPoint = 0;
        yield return new WaitForSeconds(3);
        carTarget.tag = "CarAI";
        gameObject.tag = "CarAI";
    }

    private void GetPath()
    {
        Wheel.instance.StartPlay(out waypoints, out posStart);
        gameObject.transform.position = posStart.position;
    }

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
