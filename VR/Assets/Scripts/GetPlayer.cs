using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(PlayerSpawnerPosition))]
[RequireComponent(typeof(MenuControl))]
[RequireComponent(typeof(SceneTransitionControl))]
[RequireComponent(typeof(VibrationDeviceControl))]
public class GetPlayer : MonoBehaviour
{
    public GameObject player { get; private set; }
    private void Awake()
    {
        Debug.Log("Базовый класс");
        player = Player.instance.gameObject; ;
    } 
}
