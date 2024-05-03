using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuFailedDestinate : Menu
{
    [SerializeField] private TextMeshProUGUI textTarget;
    [SerializeField] private TextMeshProUGUI textTypeOfViolation;
    public override void SetData(string nameTarget, MenuProperties menuProperties)
    {
        textTarget.text = nameTarget;
        textTypeOfViolation.text = menuProperties.ReasonFailure;
    }
}
