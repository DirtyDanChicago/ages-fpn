using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]

/// <summary>
/// This class displays the name of the object the player is looking at it is an Interactive Object.
/// </summary>

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    [Tooltip("The name displayed when the player looks at this interactive object.")]
    protected string displayText = nameof(InteractiveObject);

    public virtual string DisplayText => displayText;
    protected private AudioSource audioSource;

    //On awake, find the audio source component of the object.
    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    //Finds and plays the attached audio source, if there is no audio source catch and throw exception message.
    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {
            throw new System.Exception("Missing AudioSource component, and or audio clip.");
        }
  
        Debug.Log($"The player interacted with {gameObject.name}");
    }
}
