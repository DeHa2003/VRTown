using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersController : Controller
{
    [SerializeField] private Trigger[] triggers;
    public override void InitializeController()
    {
        base.InitializeController();
        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].Initialize();
        }
    }

    public override void ActivateController()
    {
        base.ActivateController();

        for (int i = 0; i < triggers.Length; i++)
        {
            triggers[i].Activate();
        }
    }

    public override void DeactivateController()
    {
        base.DeactivateController();

        for(int i = 0;i < triggers.Length; i++)
        {
            triggers[i].Deactivate();
        }
    }

    public override void OnDestroyController()
    {
        base.OnDestroyController();
    }
}
