using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootballGoal : MonoBehaviour, IFootballGoal
{
    private Action OnObjectTriggered;

    public void AddAction(Action action)
    {
        OnObjectTriggered += action;
    }

    public void RemoveAction(Action action)
    {
        OnObjectTriggered -= action;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<InteractionObject>())
        {
            OnObjectTriggered?.Invoke();
        }
    }
}
