using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    /// <summary>
    /// This code is used for the flashlight feature of this game. It works by turning a spotlight attached to the character on or off.
    /// </summary>

    //Flashlight audio.
    [SerializeField]
    private AudioSource flashlightAudioSource;
    //Flashlight variable.
    private Light flashlight;


    void Start()
    {
        //Gets the light component of the flashlight, and starts with it off.
        flashlight = GetComponent<Light>();
        flashlightAudioSource = GetComponent<AudioSource>();
        flashlight.enabled = false;
    }

    //Checks for user input to turn flashlight on and off.
    void Update()
    {

        //Checks for F button input.
        if (Input.GetButtonDown("Flashlight")) 
        {
            Debug.Log("Flashlight is on.");

            //Checks if the flashlight is on or off already. 
            //if it's on the flashlight turns off, and vice versa.
            flashlight.enabled = !flashlight.enabled;
            flashlightAudioSource.Play();

        }

    }
}
