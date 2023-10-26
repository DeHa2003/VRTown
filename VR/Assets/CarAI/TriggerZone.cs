using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    private GameObject car;
    private NavMeshAgent agent;
    private float speed;
    private void Awake()
    {
        car = gameObject.transform.root.gameObject;
        agent = car.GetComponent<NavMeshAgent>();
        speed = agent.speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarAI") || other.CompareTag("Player"))
        {
            audioManager.PlaySound();
            agent.speed = 0;
            agent.velocity *= 0.3f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CarAI") || other.CompareTag("Player"))
        {
            agent.speed = speed;
        }
    }
}
