using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequenceManager : MonoBehaviour
{
    public List<GameObject> EventSequence;
    public int index = 0;
    public void Signal()
    {
        EventSequence[index].SetActive(false);
        index++;
        EventSequence[index].SetActive(true);
    }
}
