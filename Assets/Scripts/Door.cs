using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows the door to be interacted with to open and close it. An animator is required 
/// for this script to work properly. 
/// </summary>


//An animator is required for this door script.
[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator animator;
    private bool isOpen = false;

    private int shouldOpenAnimParameter = Animator.StringToHash("shouldOpen");
    
    /// <summary>
    /// Using constructor to initialize displayText in the editor.
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    /// <summary>
    /// On the awake functions activation the script gets the animator
	/// component.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Script for interacting with the door.
    /// </summary>
    public override void InteractWith()
    {
		//If is open is true, the shouldOpen parameter is set to true, and the door opens.
        //It also sets the display text to "Close Door."
        if (!isOpen)
        {
            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, true);
            isOpen = true;

            displayText = ("Close Door");
        }
        //If isOpen is false, the door closes, or remains closed setting shouldOpen animator to false.
        //It also sets the display text to "Open Door."
        else
        {
            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, false);
            isOpen = false;

            displayText = ("Open Door");
        }
    }
            
 }
