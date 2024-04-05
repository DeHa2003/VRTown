using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    [SerializeField] private protected GameObject panel;

    protected AudioInteractor audioInteractor;
    public virtual void Initialize() {  }
    public virtual void OpenPanel() { panel.SetActive(true); }
    public virtual void ClosePanel() { panel.SetActive(false); }
}

public abstract class ColliderPanel : Panel
{
    [SerializeField] private protected Collider[] buttonsColliders;

    public override void OpenPanel()
    {
        base.OpenPanel();

        for (int i = 0; i < buttonsColliders.Length; i++)
        {
            buttonsColliders[i].enabled = true;
        }
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        for (int i = 0; i < buttonsColliders.Length; i++)
        {
            buttonsColliders[i].enabled = false;
        }
    }
}
