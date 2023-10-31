using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [Header("Pos spawn")]
    [SerializeField] private bool isVisiblePos;
    [SerializeField] private Color color;
    [SerializeField] private Transform posPlayerSpawn;

    private CharacterController controller;
    private GameObject player;
    private LaserController laserController;
    private FadeScreeningAndTransitions transitions;
    private VibrationDevice vibrationDevice;
    private MenuPanel menuPanel;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        menuPanel = player.GetComponent<MenuPanel>();
        laserController = player.GetComponent<LaserController>();
        transitions = player.GetComponent<FadeScreeningAndTransitions>();
        controller = player.GetComponent<CharacterController>();
        vibrationDevice = player.GetComponent<VibrationDevice>();
        controller.enabled = false;
        controller.transform.position = posPlayerSpawn.position;
        controller.enabled = true;
    }
    
    public GameObject Player()
    {
        return player;
    }

    public void ActivateLaser(bool activate)
    {
        if(laserController.enabled)
        {
            if (activate)
            {
                laserController.AddLaserPointer();
            }
            else 
            { 
                laserController.RemoveLaserPointer(); 
            }
        }
    }


    public void AddLaserController(bool add)
    {
        laserController.enabled = add;
    }
    public void AddMenuController(bool add)
    {
        if (add)
        {
            menuPanel.enabled = true;
        }
        else
        { 
            menuPanel.enabled = false;
        }

        menuPanel.enabled = add ? true : false;
    }

    public void LoadScene(int scene)
    {
        transitions.LoadScene(scene);
    }

    public void Vibration(float duration, float frequency, float amplitude)
    {
        vibrationDevice.Pulse(duration, frequency, amplitude, Valve.VR.SteamVR_Input_Sources.Any);
    }

    private void OnDrawGizmos()
    {
        if (isVisiblePos)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(posPlayerSpawn.position, 2f);
        }
    }
}
