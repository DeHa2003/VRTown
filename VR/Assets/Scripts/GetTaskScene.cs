using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTaskScene : MonoBehaviour
{
    [SerializeField] private string task;

    public string GetTask()
    {
        return task;
    }
}
