using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText1;
    [SerializeField]
    private TextMeshProUGUI textComponents;
    [SerializeField]
    private Image portrait1;
    [SerializeField]
    private Image portrait2;

    private float textSpeed;
    private int index;
    private Image currentPortrait;
    private Image otherPortrait;
    public Dialogue currentDialogue;

    private Dictionary<string, int> poses;
    private Dictionary<string, Sprite[]> characters;

    [SerializeField]
    private Sprite[] cynthiSprites = new Sprite[5];
    [SerializeField]
    private Sprite[] alonsoSprites = new Sprite[5];
    [SerializeField]
    private Sprite[] zinniaSprites = new Sprite[5];

    void Awake() {
        currentPortrait = portrait2;

        poses = new Dictionary<string, int>() 
        {
            { "neutral", 0 },
            { "happy", 1 },
            { "sad", 2 },
            { "angry", 3 },
            { "shock", 4 },
        };

        characters = new Dictionary<string, Sprite[]>() 
        {
            { "Cynthi", cynthiSprites },
            { "Alonso", alonsoSprites },
            { "Zinnia (O.S.)", zinniaSprites },
        };
    }

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
        if (currentPortrait == portrait1) 
        {
            currentPortrait = portrait2;
            otherPortrait = portrait1;
        }
        else 
        {
            currentPortrait = portrait1;
            otherPortrait = portrait2;
        }

        if (characters.ContainsKey(currentDialogue.name))
            currentPortrait.sprite = characters[currentDialogue.name][poses[currentDialogue.poses[index]]];
        currentPortrait.color = new Color(1, 1, 1, 1);
        otherPortrait.color = new Color(1, 1, 1, 0.5f);

        // string poseKey;
        // if (currentDialogue.poses.TryGetValue(index, out poseKey))
        // {
        //     Debug.Log("Pose: " + poseKey); //Should be replaced with function
        // }
        // string animationKey;
        // if (currentDialogue.animations.TryGetValue(index, out animationKey))
        // {
        //     Debug.Log("Animation: " + animationKey); //Should be replaced with function
        // }
    }

}
