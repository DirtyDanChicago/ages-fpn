using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    private Light flashLight;

    private bool isOn;

    // Start is called before the first frame update
     
    void Start()
    {
        flashLight = GetComponent<Light>();

        flashLight.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Flashlight is on.");

            flashLight.enabled = !flashLight.enabled;
        }

    }
}
