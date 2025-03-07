using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjecDetector : MonoBehaviour
{
    [SerializeField] List<GameObject> objects = new List<GameObject>();
    [SerializeField] string tag = "CanPickUp";
    [SerializeField] int count = 5;
    [SerializeField] UnityEvent onMeetCount = new UnityEvent();
    [SerializeField] bool enableRemove = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            objects.Add(other.gameObject);
            if (objects.Count >= count)
                onMeetCount.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!enableRemove) return;
        
        if (other.CompareTag(tag))
            objects.Remove(other.gameObject);
    }
}
