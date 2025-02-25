using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PianoAudioManager : MonoBehaviour
{
    public StudioEventEmitter Piano3D;  // Reference to the 3D sound emitter
    public StudioEventEmitter Piano2D; // Reference to the 2D sound emitter

    void Start()
    {
        // Ensure the 3D sound is playing at the start
        if (Piano3D != null)
        {
            Piano3D.Play();
            Debug.Log("Piano 3D sound started.");
        }
    }

    // When called, switch from 3D sound (Emitter) to 2D sound
    public void SwitchTo2DSound()
    {
        if (Piano3D != null && Piano3D.IsPlaying())
        {
            Piano3D.Stop();  // Stop the 3D sound
            Debug.Log("Piano 3D sound stopped.");
        }

        if (Piano2D != null)
        {
            Piano2D.Play(); // Start the 2D sound
            Debug.Log("Piano 2D sound started.");
        }
    }

}
