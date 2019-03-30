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

    [Tooltip("Display text when door is locked.")]
    [SerializeField]
    private string lockedDisplayText = "Locked Door";

    [Tooltip("The audio clip played when the player tries to open a locked door.")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("The audio clip played when the player tries to open door.")]
    [SerializeField]
    private AudioClip openAudioClip;


    /// <summary>
    /// Assigning a key to a door will lock the door and require the key to be used.
    /// </summary>
    [Tooltip("The item required to open this door.")]
    [SerializeField]
    private InventoryObject keyRequired;

    public override string DisplayText => isLocked ? lockedDisplayText : base.displayText;

    public AudioClip OpenAudioClip { get => openAudioClip; set => openAudioClip = value; }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(keyRequired);

    private bool isLocked;
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
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (keyRequired != null)
            isLocked = true;
    }

    /// <summary>
    /// Script for interacting with the door.
    /// </summary>
    public override void InteractWith()
    {
		//If isOpen is true, the player has the key, and the door isn't locked, the shouldOpen parameter is set to true and the door opens.
        //It also sets the display text to "Close Door."
        if (!isOpen && isLocked && HasKey)
        {
            audioSource.clip = OpenAudioClip;

            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, true);
            isOpen = true;

            lockedDisplayText = "Close Door";
            
        }
        //If isOpen is false, the player has the key, and the door isn't locked, the shouldOpen parameter is set to false and the door closes.
        //It also sets the display text to "Open Door."
        else if (isOpen && isLocked && HasKey)
        {
            audioSource.clip = OpenAudioClip;

            base.InteractWith();
            animator.SetBool(shouldOpenAnimParameter, false);
            isOpen = false;

            lockedDisplayText = "Open Door";
        }
        //If the door is locked, and the player doesn't have the key play the locked audio clip when interacting with it.
        else if (isLocked && !HasKey)
        {
            audioSource.clip = lockedAudioClip;
            base.InteractWith();
        }
    }
            
 }
