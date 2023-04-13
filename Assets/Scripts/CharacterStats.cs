using UnityEngine;


[CreateAssetMenu(fileName = "CharacterStats", menuName = "Persistance")]
public class CharacterStats : ScriptableObject
{
    public bool battleScene=false;
    public int health;

    public Vector3 overworldPos;


}


