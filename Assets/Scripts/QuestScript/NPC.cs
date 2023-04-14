using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NPC : MonoBehaviour
{
    public Transform camera;
    public Animator anim;

    public Quest quest_;
    public DialogueInteraction action;

    bool forth = true;          // going from start to end
    bool isWalking = false;
    public Vector3 startPos;
    public Vector3 endPos;
    public float speed;
    public float posError;      // distance between npc and point before going back
    
    public enum Direction {UpDown, LeftRight};
    public Direction direction;

    public float pauseTime;
    float timer = 0;

    private void Awake() 
    {
        if (direction == Direction.UpDown) anim.SetBool("UpDown", true);
        else anim.SetBool("UpDown", false);
    }

    // private void Start()
    // {
    //     quest_ = new Quest();
    //     quest_.title = "test name";
    //     quest_.description = "test description";
    // }

    private void Update() 
    {
        Patrol();
        MoveAnimation();
    }

    public void Interact()
    {
        UnityEvent afterDialogue = new UnityEvent();
        afterDialogue.AddListener(ShowQuest);
        DialogueManager.Instance.StartDialogue(action, afterDialogue);
    }

    private void Patrol() 
    {
        transform.eulerAngles = camera.eulerAngles;

        if (isWalking)
        {
            // if (forth) transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
            // else transform.position = Vector3.MoveTowards(transform.position, startPos, speed);
            if (forth) transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, speed);
            else transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, speed);
        }

        if (Vector3.Distance(transform.localPosition, endPos) < posError) 
        {
            forth = false;
            isWalking = false;
        }
        else if (Vector3.Distance(transform.localPosition, startPos) < posError) {
            forth = true;
            isWalking = false;
        }

        if (!isWalking) 
        {
            timer += Time.deltaTime;
            if (timer > pauseTime) 
            {
                timer = 0;
                isWalking = true;
            }
        }
    }

    void MoveAnimation() {
        if (isWalking) anim.SetBool("Walking", true);
        else anim.SetBool("Walking", false);
    }

    public void CompleteQuest()
    {
        quest_.is_complete = true;
    }

    public void ShowQuest()
    {
        QuestManager manager;
        manager = FindObjectOfType<QuestManager>();

        SingleQuestDisplay display;
        display = FindObjectOfType<SingleQuestDisplay>(true);

        //if quest is not there display title+des
        //with accept + reject button
        if (!(manager.FindQuest(quest_)))
        {
            display.DisplayAcceptReject();
            display.DisplayQuest(quest_);
        }

        //if quest is there but not completed
        //display quest title+des
        //have abandon quest method/button
        //abandon removes quest from list
        else if (manager.FindQuest(quest_) && (quest_.is_complete == false))
        {
            display.DisplayAbandon();
            display.DisplayQuest(quest_);
        }

        //if quest is there but completed
        //display the quest title+des
        //have a hand in button for quest
        else if (manager.FindQuest(quest_) && (quest_.is_complete == true) && (quest_.handed_in == false))
        {
            display.DisplayHandIn();
            display.DisplayQuest(quest_);
        }

        //if quest is there but handedin is true
        //debug.log("quest is done")
        //dialogue maybe
        else if (manager.FindQuest(quest_) && (quest_.handed_in == true))
        {
            Debug.Log("quest is done");
        }

    }
}
