using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText1;
    [SerializeField]
    private TextMeshProUGUI textComponents;
    [SerializeField]
    private float textSpeed;

    public Dialogue currentDialogue;
    
    private int index;


    void Update()
    {
        //make it so that you can only click inside dialogue box to proceed to next dialogue
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponents.text == currentDialogue.lines[index])
            {
                NextLine();
            }     
            else
            {
                StopAllCoroutines();
                textComponents.text = currentDialogue.lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        nameText1.text = currentDialogue.name;
        textComponents.text = string.Empty;
        PlayAnimations();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        foreach (char c in currentDialogue.lines[index].ToCharArray())
        {
            textComponents.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void NextLine()
    {
        if (index < currentDialogue.lines.Length - 1)
        {
            index++;
            textComponents.text = string.Empty;

            PlayAnimations();
            StartCoroutine(TypeLine());
        }
        //if there is no next line close the dialogue box
        else
        {
            DialogueManager.Instance.completedDialogue = true;
        }
    }

    void PlayAnimations()
    {
        string poseKey;
        if (currentDialogue.poses.TryGetValue(index, out poseKey))
        {
            Debug.Log("Pose: " + poseKey); //Should be replaced with function
        }
        string animationKey;
        if (currentDialogue.animations.TryGetValue(index, out animationKey))
        {
            Debug.Log("Animation: " + animationKey); //Should be replaced with function
        }
    }

}
