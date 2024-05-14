using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillController : Controller
{
    [SerializeField] private WindMill[] windMills;

    private void Update()
    {
        for (int i = 0; i < windMills.Length; i++)
        {
            windMills[i].Rotate();
        }
    }
}
