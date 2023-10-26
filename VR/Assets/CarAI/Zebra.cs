using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zebra : MonoBehaviour
{
    private NavMeshAgent agent;
    private float speedAgent;

    private bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.CompareTag("CarAI"))
            {
                agent = other.transform.root.GetComponent<NavMeshAgent>();
                speedAgent = agent.speed;
                agent.speed = 0;
                agent.velocity *= 0.6f;
            }
        }
    }

    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
        if(agent != null)
           agent.speed = speedAgent;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("CarUI"))
    //    {
    //        agent = other.transform.root.GetComponent<NavMeshAgent>();
    //        agent.speed = speedAgent;
    //    }
    //}
}
