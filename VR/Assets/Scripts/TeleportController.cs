using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : Controller
{
    [SerializeField] private Teleport[] teleports;
    public override void InitializeController()
    {
        base.InitializeController();

        for (int i = 0; i < teleports.Length; i++)
        {
            teleports[i].Initialize();
        }
    }
}
