using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script provides the connection to the player's inventory menu and the player's inventory list.
/// </summary>
public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;

    public InventoryMenu Instance
    {
        get
        {
            return Instance;
        }

        private set { instance = value; }
    }
}
