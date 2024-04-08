using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinateMenu_SettingsPanel : ScaleColliderPanel
{
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
}
