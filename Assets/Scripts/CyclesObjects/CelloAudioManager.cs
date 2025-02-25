using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // Ensure FMOD is included

public class CelloAudioManager : MonoBehaviour
{
    public StudioEventEmitter cello3D;  // Reference to the 3D sound emitter
    public StudioEventEmitter cello2D; // Reference to the 2D sound emitter

    void Start()
    {
        // Ensure the 3D sound is playing at the start
        if (cello3D != null)
        {
            cello3D.Play();
            Debug.Log("Cello 3D sound started.");
        }
    }

    // When called, switch from 3D sound (Emitter) to 2D sound
    public void SwitchTo2DSound()
    {
        if (cello3D != null && cello3D.IsPlaying())
        {
            cello3D.Stop();  // Stop the 3D sound
            Debug.Log("Cello 3D sound stopped.");
        }

        if (cello2D != null)
        {
            cello2D.Play(); // Start the 2D sound
            Debug.Log("Cello 2D sound started.");
        }
    }

}
