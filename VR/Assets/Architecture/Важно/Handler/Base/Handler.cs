using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Handler : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private PanelsControl[] panelsControls;
    private protected virtual void Awake()
    {
        Game.OnGameInitializedEvent += OnGameInitialized;
    }

    private protected virtual void OnGameInitialized()
    {
        inputData.Initialize();
        for (int i = 0; i < panelsControls.Length; i++)
        {
            panelsControls[i].Initialize();
        }
        Game.OnGameInitializedEvent -= OnGameInitialized;
    }
}

