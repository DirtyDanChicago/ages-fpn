using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    private FlashLight flashLight;


    // Start is called before the first frame update
     
    void Start()
    {
        flashLight = GetComponent<FlashLight>();

        flashLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Flashlight is on.");

            flashLight.enabled = true;
        }
        else if (flashLight.enabled = true && Input.GetKeyDown(KeyCode.F))
        {

            Debug.Log("Flashlight is on.");

            flashLight.enabled = false;

        }
    }
}
