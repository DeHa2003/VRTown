using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsControl : MonoBehaviour
{
    //[SerializeField] protected TransitionPanel transitionPanel;
    [SerializeField] private protected Panel[] panels;

    protected Panel panel;

    public virtual void Initialize()
    {
        //transitionPanel.Initialize();
        //CloseTransitionsPanel();

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].Initialize();
        }
    }

    //public void OpenTransitionsPanel(int value)
    //{
    //    transitionPanel.SetSceneNumber(value);
    //    OpenPanel(transitionPanel);
    //}

    //public void CloseTransitionsPanel()
    //{
    //    transitionPanel.ClosePanel();
    //}

    public void OpenPanel(Panel panel)
    {
        if (this.panel != null)
        {
            this.panel.ClosePanel();
            this.panel = null;
        }

        this.panel = panel;
        this.panel.OpenPanel();
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
