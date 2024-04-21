using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsObjectsController : Controller
{
    [SerializeField] private InteractionObject[] interactionObjects;

    public override void InitializeController()
    {
        for(int i = 0; i < interactionObjects.Length; i++)
        {
            interactionObjects[i].Initialize();
        }
    }
}
