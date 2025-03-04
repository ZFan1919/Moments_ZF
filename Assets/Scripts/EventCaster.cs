using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCaster : MonoBehaviour
{
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;

    [SerializeField] bool onceOnly = false;
    [SerializeField] bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (onceOnly && isTriggered) return;

        if (other.CompareTag("Player"))
        {
            onEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (onceOnly && isTriggered) return;

        if (other.CompareTag("Player"))
        {
            onExit.Invoke();
            isTriggered = true;
        }
    }
}
