using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuDestinate : Menu
{
    [SerializeField] private TextMeshProUGUI textTarget;

    public override void SetData(string target, MenuProperties menuProperties)
    {
        textTarget.text = target;
    }
}
