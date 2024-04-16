using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform posToTeleport;
    private IPlayerTransitionInteractorProvider playerTransitionInteractorProvider;

    public void Initialize()
    {
        playerTransitionInteractorProvider = Game.GetInterface<IPlayerTransitionInteractorProvider, TransitionInteractor>();
    }

    private void Teleportation()
    {
        playerTransitionInteractorProvider.TransitionToPosition_Fade(posToTeleport.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Player>())
        {
            Teleportation();
        }
    }
}
