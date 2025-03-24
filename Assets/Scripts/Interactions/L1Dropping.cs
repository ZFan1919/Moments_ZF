using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // FMOD Studio for audio

public class L1Dropping : MonoBehaviour
{
    public StudioEventEmitter DropOffice; // Reference to the FMOD Event Emitter for the drop sound

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "CanPickUp" tag
        if (other.CompareTag("CanPickUp"))
        {
            // Play the drop sound
            DropOffice.Play();
        }
    }
}