using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Handler : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private Controller[] controllers;
    private protected virtual void Awake()
    {
        Game.OnGameInitializedEvent += OnGameInitialized;
    }

    private protected virtual void OnGameInitialized()
    {
        inputData.Initialize();
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].InitializeController();
        }
        Game.OnGameInitializedEvent -= OnGameInitialized;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].OnDestroyController();
        }
    }
}

