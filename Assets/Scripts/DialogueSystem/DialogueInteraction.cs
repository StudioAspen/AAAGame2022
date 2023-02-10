using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueInteraction", order = 1)]
public class DialogueInteraction : ScriptableObject
{
    public Dialogue[] dialogues;

#if UNITY_EDITOR
    [SerializeField]
    private TextAsset CSV;
    [ContextMenu("PopulateData")]
    public void PopulateData()
    {
        string[] rows = CSV.text.Split('\n');
        string[] currentRow;
        List<Dialogue> dialoguesHolder = new List<Dialogue>();

        //Initalizing dialogue variables
        string currentName = rows[1].Split(',')[0]; //Initializing first name
        List<string> currentSentences = new List<string>();

        int animationIterator = 0;
        Dictionary<int, string> currentAnimations = new Dictionary<int, string>();
        int poseIterator = 0;
        Dictionary<int, string> currentPoses = new Dictionary<int, string>();


        for (int i = 1; i < rows.Length; i++)
        {
            currentRow = rows[i].Split(',', 3);

            if (currentRow[0] != "" && currentName != currentRow[0])
            {
                AddDialogue();

                //Resetting for new dialogue
                currentName = currentRow[0];
                currentSentences = new List<string>();
                currentAnimations = new Dictionary<int, string>();
                currentPoses = new Dictionary<int, string>();

                animationIterator = 0;
                poseIterator = 0;
            }

            //Adding poses
            if (currentRow[1] != "")
            {
                currentPoses.Add(poseIterator, currentRow[1]);
            }

            //Adding sentences
            if (currentRow[2] != "")
            {
                currentSentences.Add(currentRow[2]);
            }
            
            //Adding animation
            // if (currentRow[3] != "")
            // {
            //     currentAnimations.Add(animationIterator, currentRow[3]);
            // }

            animationIterator++;
            poseIterator++;
        }
            
        //Adding the last dialogue
        AddDialogue();
        dialogues = dialoguesHolder.ToArray();

        //Adding dialogue 
        void AddDialogue()
        {
            Dialogue dialogue = new Dialogue(currentName, currentSentences.ToArray(), currentAnimations, currentPoses);
            dialoguesHolder.Add(dialogue);
        }

        Debug.Log("data populated!");
    }
#endif
}
