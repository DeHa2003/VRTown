using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject otherTeleport;
    [SerializeField] private Transform posToTeleport;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration;

    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private IEnumerator Teleporting()
    {
        SteamVR_Fade.Start(startColor, duration);

        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
        otherTeleport.SetActive(true);
        player.position = posToTeleport.position;

        SteamVR_Fade.Start(endColor, duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(nameof(Teleporting));
        }
    }
}
