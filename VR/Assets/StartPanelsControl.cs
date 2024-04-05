using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelsControl : PanelsControl
{
    [SerializeField] private Panel startMenuPanel;

    public override void Initialize()
    {
        base.Initialize();
        startMenuPanel.Initialize();
    }
}
