using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity; // To use FMOD Studio for audio

public class L3ObjectDetector : MonoBehaviour
{
    public TMPro.TMP_Text countText; // UI text reference
    [SerializeField] UnityEvent onMeetCount = new UnityEvent(); // Event triggered when all objects are collected

    // List of required objects
    private HashSet<string> requiredObjects = new HashSet<string> { "Trash Can", "Pen Cup", "Plant", "Computer", "Chair" };
    private HashSet<string> collectedObjects = new HashSet<string>(); // Track collected objects by name

    void Start()
    {
        UpdateCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanPickUp")) // Check correct tag
        {
            string objectName = other.gameObject.name;

            // Ensure it's a required object and hasn't been collected
            if (requiredObjects.Contains(objectName) && !collectedObjects.Contains(objectName))
            {
                collectedObjects.Add(objectName); // Add to collected list           

                UpdateCountText(); // Update UI

                // Check if all required objects are collected
                if (collectedObjects.Count == requiredObjects.Count)
                {
                    Debug.Log("All objects collected!");
                    onMeetCount.Invoke(); // Trigger event when all are collected
                }
            }
        }
    }

    void UpdateCountText()
    {
        countText.text = "Objects Collected: " + collectedObjects.Count + " / " + requiredObjects.Count;
    }
}


