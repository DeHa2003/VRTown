using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Boolean menuAction;

    [SerializeField] private GameObject menuPref;
    [SerializeField] private Transform posSpawn;

    private LaserController laserController;
    private FadeScreeningAndTransitions transitions;

    private GameObject menu;
    
    private void Awake()
    {
        laserController = GetComponent<LaserController>();
        transitions = GetComponent<FadeScreeningAndTransitions>();
    }

    private void Update()
    {
        if(menuAction.GetStateDown(SteamVR_Input_Sources.Any) && menu == null)
        {
            if(Time.deltaTime > 0)
            {
                menu = Instantiate(menuPref, posSpawn.position, posSpawn.rotation);
                laserController.AddLaserPointer();
            }
        }
        else if(menuAction.GetStateDown(SteamVR_Input_Sources.Any) && menu != null)
        {
            if (Time.deltaTime > 0)
            {
                Destroy(menu);
                laserController.RemoveLaserPointer();
            }
        }
    }

    public void PlayScene(int sceneNum)
    {
        transitions.LoadScene(sceneNum);
    }

    public void ActivateDeactivate(bool isActive)
    {
        if(isActive)
        {
            gameObject.GetComponent<MenuPanel>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MenuPanel>().enabled = false;
        }
    }
}
