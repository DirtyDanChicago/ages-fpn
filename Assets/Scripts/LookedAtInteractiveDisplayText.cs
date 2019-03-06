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
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
        displayText.text = lookedAtInteractive.DisplayText;
        else
        {
            displayText.text = "";
        }
    }


}
