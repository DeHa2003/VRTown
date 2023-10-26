using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub : MonoBehaviour
{
    public void Awake()
    {
        Single.instance.Test();
    }
}
