using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPref;
    [SerializeField] private Transform posSpawn;

    private GameObject menu = null;
    private void OnEnable()
    {
        Laser.OnActivateLaser += InstantiateMenuPanel;
        Laser.OnDiactivateLaser += DeleteMenuPanel;
    }

    private void OnDisable()
    {
        Laser.OnActivateLaser -= InstantiateMenuPanel;
        Laser.OnDiactivateLaser -= DeleteMenuPanel;
    }

    private void InstantiateMenuPanel()
    {
        if(Time.deltaTime > 0)
        menu = Instantiate(menuPref, posSpawn.position, posSpawn.rotation);
    }

    private void DeleteMenuPanel()
    {
        if(Time.deltaTime > 0)
        Destroy(menu);
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
