using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuCompletedDestinate : Menu
{
    [SerializeField] private TextMeshProUGUI textTarget;
    public override void SetData(string nameTarget, MenuProperties menuProperties)
    {
        textTarget.text = nameTarget;
    }
}
