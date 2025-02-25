using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GrabObject : MonoBehaviour
{
    public StudioEventEmitter PickUp; // 🎵 FMOD event for pick-up sound
    private GameObject grabbedObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Replace with your actual grab key
        {
            TryGrab();
        }
    }

    void TryGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f)) // Adjust range as needed
        {
            if (hit.collider.CompareTag("CanPickUp"))
            {
                grabbedObject = hit.collider.gameObject;

                // Play the Pick-Up Sound at grab moment
                PickUp.Play();

                // Example of making the object follow the player (adjust based on your system)
                grabbedObject.transform.SetParent(transform);
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
