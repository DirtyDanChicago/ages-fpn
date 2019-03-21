using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This UI text displays info about he currently looked at interactive element. 
/// If the player is not currently looking at an interactive element, the text should be hidden.
/// </summary>
public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;

    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
            displayText.text = lookedAtInteractive.DisplayText;
        else
            displayText.text = string.Empty;
    }

    /// <summary>
    /// This is the event handler for the Looked At Interactive Changed.
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new interactive the player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
    }

    #region Event Subscription
    private void OnEnable()
    {
        DetectInteractable.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectInteractable.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
