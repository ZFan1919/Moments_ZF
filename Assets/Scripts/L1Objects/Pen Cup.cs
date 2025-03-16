using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PenCup : MonoBehaviour
{
    [SerializeField] private UnityEvent onMeetCount; // Event triggered when chair is collected
    private bool isCollected = false; // Prevent multiple triggers

    void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("CanPickUp") && other.gameObject.name == "Pen Cup")
        {
            isCollected = true;
            onMeetCount.Invoke(); // Trigger event only when Chair is collected
        }
    }
}
