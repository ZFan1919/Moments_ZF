using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BellAudioManager : MonoBehaviour
{
    public StudioEventEmitter Bell3D;  // Reference to the 3D sound emitter
    public StudioEventEmitter Bell2D; // Reference to the 2D sound emitter

    void Start()
    {
        // Ensure the 3D sound is playing at the start
        if (Bell3D != null)
        {
            Bell3D.Play();
            Debug.Log("Bell 3D sound started.");
        }
    }

    // When called, switch from 3D sound (Emitter) to 2D sound
    public void SwitchTo2DSound()
    {
        if (Bell3D != null && Bell3D.IsPlaying())
        {
            Bell3D.Stop();  // Stop the 3D sound
            Debug.Log("Bell 3D sound stopped.");
        }

        if (Bell2D != null)
        {
            Bell2D.Play(); // Start the 2D sound
            Debug.Log("Bell 2D sound started.");
        }
    }

}
