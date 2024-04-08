using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsControl : MonoBehaviour
{
    [SerializeField] private protected Panel[] panels;

    protected Panel currentPanel;

    public virtual void Initialize()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].Initialize();
        }

        OpenPanel(panels[0]);
    }

    public void OpenPanel(Panel panel)
    {
        if (this.currentPanel != null)
        {
            this.currentPanel.ClosePanel(); 
            this.currentPanel = null;
        }

        this.currentPanel = panel;
        this.currentPanel.OpenPanel();
    }

    public void OpenOtherPanel(Panel panel)
    {
        panel.OpenPanel();
    }

    public void CloseOtherPanel(Panel panel)
    {
        panel.ClosePanel();
    }
}
