using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public virtual void InitializeController() { }
    public virtual void ActivateController() { }
    public virtual void DeactivateController() { }
    public virtual void OnDestroyController() { }
}
