using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "CreateTest", fileName = "TEST")]
public class Food : ScriptableObject
{
    public int price;
    public Image image;
    public new string name;
}
