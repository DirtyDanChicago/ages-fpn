using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    [Tooltip("The name displayed when the player looks at this interactive object.")]
    protected string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {
            throw new System.Exception("Missing AudioSource component.");
        }

        
        Debug.Log($"The player interacted with {gameObject.name}");
    }
}
