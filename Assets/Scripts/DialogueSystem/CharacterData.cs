using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;

public class CharacterData : MonoBehaviour
{
    [Serializable]
    public struct CharacterPosesDictionary
    {
        public string name;
        public CharacterPoses pose;
    }
    public CharacterPosesDictionary[] characterPoses;
}
