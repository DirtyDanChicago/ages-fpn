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
    [Tooltip("Check this box to indicate whether or not the door is locked.")]
    [SerializeField]
    private bool isLocked = false;

    [Tooltip("Display text when door is locked.")]
    [SerializeField]
    private string lockedDisplayText = "Locked Door";

    [Tooltip("The audio clip played when the player tries to open a locked door.")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("The audio clip played when the player tries to open door.")]
    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText : base.displayText;

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
		//If is open is true and the door isn't locked, the shouldOpen parameter is set to true and the door opens.
        //It also sets the display text to "Close Door."
        if (!isOpen && !isLocked)
        {
            audioSource.clip = openAudioClip;

            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, true);
            isOpen = true;

            displayText = ("Close Door");
        }
        //If isOpen is false and the door isn't locked, the door closes, or remains closed setting shouldOpen animator to false.
        //It also sets the display text to "Open Door."
        else if (isOpen && !isLocked)
        {
            audioSource.clip = openAudioClip;

            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, false);
            isOpen = false;

            displayText = ("Open Door");
        }
        //If the door is locked, play the locked audio clip when interacting with it.
        else if (isLocked)
        {
            audioSource.clip = lockedAudioClip;
            base.InteractWith();
        }
    }
            
 }
