using TMPro;
using UnityEngine;

public class SingleQuestDisplay : MonoBehaviour
{
    public Quest quest_;
    public GameObject quest_window;
    public GameObject accept_button;
    public GameObject reject_button;
    public GameObject abandon_button;
    public GameObject handin_button;


    public TextMeshProUGUI title_text;
    public TextMeshProUGUI description_text;

    public void DisplayQuest(Quest quest)
    {
        quest_window.SetActive(true);

        quest_ = quest;
        title_text.text = quest.title;
        description_text.text = quest.description;
    }


    public void Reject()
    {
        quest_window.SetActive(false);
    }

    public void Accept(Quest quest)
    {
        QuestManager manager;
        manager = FindObjectOfType<QuestManager>();
        manager.AddQuest(quest);
    }

    public void Abandon(Quest quest)
    {
        QuestManager manager;
        manager = FindObjectOfType<QuestManager>();
        manager.RemoveQuest(quest);
    }

    public void HandIn(Quest quest)
    {
        QuestManager manager;
        manager = FindObjectOfType<QuestManager>();
        manager.HandInQuest(quest);
    }

    public void DisplayAcceptReject()
    {
        abandon_button.SetActive(false);
        handin_button.SetActive(false);
    }

    public void DisplayAbandon()
    {
        accept_button.SetActive(false);
        reject_button.SetActive(false);
        handin_button.SetActive(false);
    }

    public void DisplayHandIn()
    {
        accept_button.SetActive(false);
        reject_button.SetActive(false);
        abandon_button.SetActive(false);
    }
}
