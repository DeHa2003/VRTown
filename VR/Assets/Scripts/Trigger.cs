using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField] protected TriggerType triggerType;

    protected PlayerController playerController;
    protected bool isActive = false;

    public virtual void Initialize() 
    {
        playerController = Handler.Instance.GetController<PlayerController>();
    }

    public virtual void Activate()
    {
        isActive = true;
    }

    public virtual void Deactivate()
    {
        isActive = false;
    }
}

public enum TriggerType
{
    Wheel, PedestrianCrossing, Finish
}
