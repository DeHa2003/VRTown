using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Handler : MonoBehaviour
{
    [SerializeField] protected InputData[] inputData;
    [SerializeField] protected UIObject[] uIObjects;
    [SerializeField] protected Controller[] controllers;

    protected Dictionary<Type, Controller> controllersMap = new Dictionary<Type, Controller>();

    public static Handler Instance { get; private set; }

    private protected virtual void Awake()
    {
        Instance = this;
        Game.OnGameInitializedEvent += OnGameInitialized;
    }

    private protected virtual void OnGameInitialized()
    {
        for (int i = 0; i < inputData.Length; i++)
        {
            inputData[i].Initialize();
        }

        for (int i = 0; i < uIObjects.Length; i++)
        {
            uIObjects[i].Initialize();
        }

        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].InitializeController();
            controllersMap.Add(controllers[i].GetType(), controllers[i]);
        }

        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].ActivateController();
        }
        Game.OnGameInitializedEvent -= OnGameInitialized;
    }

    protected void OnDestroy()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].DeactivateController();
        }

        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].OnDestroyController();
        }
    }

    public T GetController<T>() where T : Controller
    {
        return controllersMap.Values.OfType<T>().FirstOrDefault();
    }
}

