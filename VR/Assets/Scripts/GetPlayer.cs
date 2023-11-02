using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSpawnerControl))]
[RequireComponent(typeof(MenuControl))]
[RequireComponent(typeof(LaserControl))]
[RequireComponent(typeof(SceneTransitionControl))]
[RequireComponent(typeof(VibrationDeviceControl))]
public class GetPlayer : MonoBehaviour
{
    public GameObject player { get; private set; }
    private void Awake()
    {
        Debug.Log("Базовый класс");
        player = GameObject.FindWithTag("Player");
    } 
}
