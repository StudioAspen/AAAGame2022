using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string name;
    public string[] sentences;
    public Dictionary<int, string> animations;
    public Dictionary<int, string> poses;
}
