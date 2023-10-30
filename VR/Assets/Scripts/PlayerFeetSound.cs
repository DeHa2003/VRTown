using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetSound : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AudioSource sourceFeet;
    [Header("Audio clips")]
    [SerializeField] private AudioClip roomWalk;
    [SerializeField] private AudioClip streetWalk;
    [SerializeField] private AudioClip threeWalk;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (characterController.isGrounded)
        {
            switch (hit.gameObject.layer)
            {
                case 10:
                    OnWalk(roomWalk, 2, 1.3f);
                    break;
                case 11:
                    OnWalk(streetWalk, 2, 1.4f);
                    break;
                case 12:
                    OnWalk(threeWalk, 2, 1.5f);
                    break;
                default:
                    sourceFeet.clip = null;
                    break;
            }
        }
        else
        {
            sourceFeet.clip = null;
        }
    }

    private void OnWalk(AudioClip audioClip, float dependenceVolume, float dependencePitch)
    {
        if (characterController.velocity.magnitude <= 0.1 || Time.deltaTime == 0)
        {
            sourceFeet.clip = null;
            Debug.Log("Стоим");
        }
        else
        {
            if (sourceFeet.clip != audioClip)
            {
                sourceFeet.clip = audioClip;
                sourceFeet.Play();
            }
            sourceFeet.volume = characterController.velocity.magnitude / dependenceVolume;
            sourceFeet.pitch = characterController.velocity.magnitude / dependencePitch;
            Debug.Log("Двигаемся");
        }
    }
}
