using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField] protected TriggerType triggerType;

    protected PlayerController playerController;

    public virtual void Initialize() 
    {
        playerController = Handler.Instance.GetController<PlayerController>();
    }
}

public enum TriggerType
{
    Wheel, PedestrianCrossing, Finish
}
