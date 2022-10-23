using UnityEngine;
using UnityEditor;
using System.IO;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueInteraction", order = 1)]
public class DialogueInteraction : ScriptableObject
{
    [SerializeField]  
    private TextAsset CSV;
    public Dialogue[] dialogues;
    

    public void PopulateData(CharacterData characterData)
    {
        string[] rows = CSV.text.Split('\n');
        string[] currentRow;
        for(int i = 0; i < rows.Length; i++)
        {
            currentRow = rows[i].Split(',');
        }
    }
}
