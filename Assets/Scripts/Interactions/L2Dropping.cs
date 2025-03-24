using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // FMOD Studio for audio

public class L2Dropping : MonoBehaviour
{
    public StudioEventEmitter DropForest; // Reference to the FMOD Event Emitter for the drop sound

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "CanPickUp" tag
        if (other.CompareTag("CanPickUp"))
        {
            // Play the drop sound
            DropForest.Play();
        }
    }
}
