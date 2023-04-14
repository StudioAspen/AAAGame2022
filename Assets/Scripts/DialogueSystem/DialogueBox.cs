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
    public Image portrait1;
    public Image portrait2;

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
    private Sprite[] almomsoSprites = new Sprite[5];
    [SerializeField]
    private Sprite judgeSprite;
    [SerializeField]
    private Sprite blankSprite;

    void Awake() {
        currentPortrait = portrait2;
        otherPortrait = portrait1;

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
            { "Prof. Aurea", almomsoSprites },
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
        if (currentDialogue.name == "ACTION") 
        {
            nameText1.text = string.Empty;
        }
        else if (currentDialogue.name == "Alonso") 
        {
            currentPortrait = portrait1;
            otherPortrait = portrait2;
            currentPortrait.gameObject.SetActive(true);
            nameText1.text = currentDialogue.name;
        } 
        // else if (currentDialogue.name == "Cynthi" ||
        //     currentDialogue.name == "Prof. Aurea")
        else
        {
            currentPortrait = portrait2;
            otherPortrait = portrait1;
            currentPortrait.gameObject.SetActive(true);
            nameText1.text = currentDialogue.name;
        }

        index = 0;
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
        if (currentDialogue.name == "ACTION")
        {
            currentPortrait.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
            otherPortrait.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
        }
        else if (characters.ContainsKey(currentDialogue.name))
        {
            currentPortrait.sprite = characters[currentDialogue.name][poses[currentDialogue.poses[index]]];
            currentPortrait.color = new Color(1, 1, 1, 1);
            otherPortrait.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
        }
        else if (currentDialogue.name == "Judge")
        {
            currentPortrait.sprite = judgeSprite;
            currentPortrait.color = new Color(1, 1, 1, 1);
            otherPortrait.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
        }
        else 
        {
            currentPortrait.sprite = blankSprite;
            currentPortrait.color = new Color(1, 1, 1, 1);
            otherPortrait.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
        }

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
