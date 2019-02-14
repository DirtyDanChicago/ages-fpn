using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    //This code is used for the flashlight feature of this game.
    //It works by turning a spotlight attached to the character on or off.


    //Flashlight variable.
    private Light flashLight;
   
     
    void Start()
    {
		//Gets the light component of the flashlight, and starts with it off.
		flashLight = GetComponent<Light>();
        flashLight.enabled = false;
    }

   
    void FixedUpdate()
    {
        
        //Checks for F button input.
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Flashlight is on.");

            //Checks if the flashlight is on or off already. 
			//if it's on the flashlight turns off, and vice versa.
            flashLight.enabled = !flashLight.enabled;

        }

    }
}
