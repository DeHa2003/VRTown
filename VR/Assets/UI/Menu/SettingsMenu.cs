using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private List<BoxCollider> buttonsColliders;

    private void OnEnable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = true;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < buttonsColliders.Count; i++)
        {
            buttonsColliders[i].enabled = false;
        }
    }

    public void ChangeColorDefaultLaser(int number)
    {
        switch (number)
        {
            case 1:
                SettingsScript.colorLaserDefault = Color.white;
                break;
            case 2:
                SettingsScript.colorLaserDefault = Color.red;
                break;
            case 3:
                SettingsScript.colorLaserDefault = Color.green;
                break;
        }
    }

    public void ChangeColorClickLaser(int number)
    {
        switch (number)
        {
            case 1:
                SettingsScript.colorLaserClick = Color.black;
                break;
            case 2:
                SettingsScript.colorLaserClick = Color.grey;
                break;
            case 3:
                SettingsScript.colorLaserClick = Color.blue;
                break;
        }
    }

    public void OpenStartPanel(GameObject panel)
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
    }
}
