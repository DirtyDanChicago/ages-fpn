using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects whether or not the player presses the interact button while looking at an IInteract object.
/// It then calls that IInteractive's InteractWith function.
/// </summary>

public class InteractWithLookedAt : MonoBehaviour
{

    private IInteractive lookedAtInteractive;

    void Update()
    {

        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            //Debug.Log("Player pressed the interact button.");

            lookedAtInteractive.InteractWith();
        }

    }

    /// <summary>
    /// This is the event handler for the Looked At Interactive Changed.
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new interactive the player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    private void OnEnable()
    {
        DetectInteractable.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectInteractable.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }


}
