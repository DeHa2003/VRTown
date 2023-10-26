using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random = UnityEngine.Random;

public class CarAI : MonoBehaviour
{
    [Header("Car position")]// Assign a Gameobject representing the front of the car
    [SerializeField] private Transform carPosition;// Look at the documentation for a detailed explanation
    [SerializeField] private GameObject carTarget;
    private Wheels wheels;
    private Vector3 PositionToFollow = Vector3.zero;
    private int currentWayPoint;
    private int NavMeshLayerBite;
    private List<Transform> waypoints = new List<Transform>();
    private NavMeshAgent agent;
    private Transform posStart;

    IEnumerator Start() 
    {
        wheels = GameObject.FindGameObjectWithTag("Wheels").GetComponent<Wheels>();
        wheels.StartPlay(out waypoints, out posStart);
        gameObject.transform.position = posStart.position;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(7, 12);
        currentWayPoint = 0;
        yield return new WaitForSeconds(3);
        carTarget.tag = "CarAI";
        gameObject.tag = "CarAI";
    }

    void FixedUpdate()
    {
        agent.SetDestination(PositionToFollow);
        PathProgress();
    }

    private void PathProgress() //Checks if the agent has reached the currentWayPoint or not. If yes, it will assign the next waypoint as the currentWayPoint depending on the input
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
                //allowMovement = true;
                if (PositionToFollow != null && carPosition!=null)
                {
                    if (Vector3.Distance(carPosition.position, PositionToFollow) < 2f)
                        currentWayPoint++;
                }
            }
        }
    }
}
