using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestCollision : MonoBehaviour
{
    public NPC npc;

    private void Start()
    {
        npc = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>();
    }
    private void OnTriggerEnter(Collider other)
    {
        npc.Interact();
    }
}
