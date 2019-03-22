using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all the things the player can interact with.
/// </summary>
public interface IInteractive
{
    string DisplayText { get; }
    void InteractWith();
}
