using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private string task;

    public string GetTask()
    {
        return task;
    }
}
