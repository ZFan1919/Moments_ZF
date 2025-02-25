using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // Ensure FMOD is included

public class ViolaAudioManager : MonoBehaviour
{
    public StudioEventEmitter viola3D;  // Reference to the 3D sound emitter
    public StudioEventEmitter viola2D; // Reference to the 2D sound emitter

    void Start()
    {
        // Ensure the 3D sound is playing at the start
        if (viola3D != null)
        {
            viola3D.Play();
            Debug.Log("viola 3D sound started.");
        }
    }

    // When called, switch from 3D sound (Emitter) to 2D sound
    public void SwitchTo2DSound()
    {
        if (viola3D != null && viola3D.IsPlaying())
        {
            viola3D.Stop();  // Stop the 3D sound
            Debug.Log("viola 3D sound stopped.");
        }

        if (viola2D != null)
        {
            viola2D.Play(); // Start the 2D sound
            Debug.Log("viola 2D sound started.");
        }
    }

}
