using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToEvent : MonoBehaviour
{
    private EventSequenceManager eventSequenceManager;
    private int eventSequenceSize;

    [SerializeField]
    private Pointer pointer;
    // Start is called before the first frame update
    void Start()
    {
        eventSequenceManager = FindObjectOfType<EventSequenceManager>();
        eventSequenceSize = eventSequenceManager.EventSequence.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSequenceManager.index < eventSequenceSize)
        {
            Vector3 targetPosition = eventSequenceManager.EventSequence[eventSequenceManager.index].transform.position;
            pointer.PointTo(targetPosition);
        }
    }
}
