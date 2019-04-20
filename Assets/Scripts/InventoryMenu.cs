using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script provides the connection to the player's inventory menu and the player's inventory list.
/// Includes debugs to make sure you only have on instance of the InventoryMenu script in the scene.
/// </summary>
public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instance, make sure the Inventory menu script is applied to object.");

            return instance;
        }

        private set { instance = value; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
           throw new System.Exception("There is already an instance of InventoryMenu, there can only be one.");
    }
}
