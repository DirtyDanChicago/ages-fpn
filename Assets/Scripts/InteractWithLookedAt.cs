using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects whether or not the player presses the interact button while looking at an IInteract object.
/// It then calls that IInteractive's InteractWith function.
/// </summary>

public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectInteractable detectInteractable;

    void Update()
    {
        
        if (Input.GetButtonDown("Interact") && detectInteractable.LookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
        }

    }
}
