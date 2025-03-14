 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Phone : MonoBehaviour
{
    public Transform player;           // Reference to the player Transform
    public StudioEventEmitter PhoneS; // Reference to FMOD event emitter for PhoneS
    public StudioEventEmitter PhoneF; // Reference to FMOD event emitter for PhoneF
    public float switchDistance = 3f;  // Distance at which the event switches (1 meter)

    private bool isPhoneFPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        PhoneS.Play();
        // Ensure PhoneF event is stopped at the start
        PhoneF.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player and the Phone
        float distance = Vector3.Distance(player.position, transform.position);

        // Switch events based on the player's distance
        if (distance < switchDistance && !isPhoneFPlaying)
        {
            SwitchToPhoneF();
        }
        else if (distance >= switchDistance && isPhoneFPlaying)
        {
            SwitchToPhoneS();
        }
    }

    void SwitchToPhoneF()
    {
        // Stop the 'PhoneS' event and play 'PhoneF'
        PhoneS.Stop();
        PhoneF.Play();

        isPhoneFPlaying = true;
    }

    void SwitchToPhoneS()
    {
        // Stop the 'PhoneF' event and play 'PhoneS'
        PhoneF.Stop();
        PhoneS.Play();

        isPhoneFPlaying = false;
    }
}
