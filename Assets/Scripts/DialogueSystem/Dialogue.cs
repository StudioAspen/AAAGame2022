using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3, 10)]
    public string[] poses;
    public string[] lines;
    // public Dictionary<int, string> animations;
    // public Dictionary<int, string> poses;

    public Dialogue()
    {
        name = "";
        poses = new string[1];
        lines = new string[1];
        // animations = new Dictionary<int, string>();
        // poses = new Dictionary<int, string>();
    }

    // public Dialogue(string name_, string[] lines_, Dictionary<int, string> animations_, Dictionary<int, string> poses_)
    // {
    //     name = name_;
    //     lines = lines_;
    //     animations = animations_;
    //     poses = poses_;
    // }

    public Dialogue(string name_, string[] poses_, string[] lines_)
    {
        name = name_;
        poses = poses_;
        lines = lines_;
    }
}
