using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single : MonoBehaviour
{
    public static Single instance;

    private void Awake()
    {
        instance = this;
    }
}
