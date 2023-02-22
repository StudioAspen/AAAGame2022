using System;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterPoses", order = 1)]
public class CharacterPoses : ScriptableObject
{
    //public string name;
    public Image[] poses;
}
