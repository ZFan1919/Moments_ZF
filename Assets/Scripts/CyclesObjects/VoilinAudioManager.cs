using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // Ensure FMOD is included

public class VoilinAudioManager : MonoBehaviour
{
    public StudioEventEmitter Voilin3D;  // Reference to the 3D sound emitter
    public StudioEventEmitter Voilin2D; // Reference to the 2D sound emitter

    void Start()
    {
        // Ensure the 3D sound is playing at the start
        if (Voilin3D != null)
        {
            Voilin3D.Play();
            Debug.Log("Voilin 3D sound started.");
        }
    }

    // When called, switch from 3D sound (Emitter) to 2D sound
    public void SwitchTo2DSound()
    {
        if (Voilin3D != null && Voilin3D.IsPlaying())
        {
            Voilin3D.Stop();  // Stop the 3D sound
            Debug.Log("Voilin 3D sound stopped.");
        }

        if (Voilin2D != null)
        {
            Voilin2D.Play(); // Start the 2D sound
            Debug.Log("Voilin 2D sound started.");
        }
    }

}
