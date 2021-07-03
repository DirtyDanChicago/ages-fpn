using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{

    [SerializeField]
    [Tooltip("Place the object you want to be toggled on and off in here.")]
    private GameObject objectToToggle;

    [SerializeField]
    [Tooltip("Can the player interact with this more than once.")]
    private bool isReuseable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// This function toggles the active self value for the object with the player interacts with this item.
    /// </summary>
    public override void InteractWith()
    {

        if (isReuseable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);

            hasBeenUsed = true;

            if (!isReuseable) displayText = string.Empty;
        }


    }

}
