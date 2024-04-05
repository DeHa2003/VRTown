using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsObjectsControl : MonoBehaviour
{
    [SerializeField] private InteractionObject[] interactionObjects;

    public void Initialize()
    {
        for(int i = 0; i < interactionObjects.Length; i++)
        {
            interactionObjects[i].Initialize();
        }
    }
}
