using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private InteractionObjectAudioVelocity interactionObjectAudio;
    public virtual void Initialize()
    {
        interactionObjectAudio.Initialize();
    }
}
