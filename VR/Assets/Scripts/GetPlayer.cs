using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(PlayerPosition))]
[RequireComponent(typeof(MenuControl))]
[RequireComponent(typeof(SceneTransitionControl))]
[RequireComponent(typeof(VibrationDeviceControl))]
public class GetPlayer : MonoBehaviour
{
    public GameObject player { get; private set; }
    private void Awake()
    {
        Debug.Log("������� �����");
        player = Player.instance.gameObject; ;
    } 
}
