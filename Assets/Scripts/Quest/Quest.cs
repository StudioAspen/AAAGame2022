using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public bool completed;
    public bool gsCompleted { get; set; }

    public bool handed_in;
    public bool gsHanded_in { get; set; }
}
