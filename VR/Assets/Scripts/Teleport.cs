using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] private PlayerPosition posToTeleport;
    private IPlayerTransitionInteractorProvider playerTransitionInteractorProvider;

    public void Initialize()
    {
        playerTransitionInteractorProvider = Game.GetInterface<IPlayerTransitionInteractorProvider, TransitionInteractor>();
    }

    private void Teleportation()
    {
        playerTransitionInteractorProvider.TransitionToPosition_Fade(posToTeleport.GetPlayerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Player>())
        {
            Teleportation();
            Deactivate();
            Invoke(nameof(Activate), 3);
        }
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if(posToTeleport != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, posToTeleport.GetPlayerTransform.position);
        }
    }
}
