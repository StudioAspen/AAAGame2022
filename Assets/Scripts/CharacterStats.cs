using UnityEngine;


[CreateAssetMenu(fileName = "CharacterStats", menuName = "Persistance")]
public class CharacterStats : ScriptableObject
{
    public bool battleScene=false;
    public int health;
    public bool isOtherScene= true;

    public Vector3 overworldPos;
    public Vector3 otherScenePos;

}


