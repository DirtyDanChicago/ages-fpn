using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectScript : InteractiveObject
{
    //TODO: Add long description field.
    //TODO: Add a field for an icon.

    //Variables to help find the collider, and renderer of the Inventory Objects.
    private new Collider collider;
    private new Renderer renderer;

    private void Start()
    {
        //Initialize the components.
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
    }

    public InventoryObjectScript()
    {
        displayText = nameof(InventoryObjectScript);
    }

    /// <summary>
    /// When the player interacts with an inventory related object, 2 things need to happen. 
    /// 1: Put the object into the players inventory object list.
    /// 2: Remove the object from the game world.
    /// 
    /// This now hides the objects, and adds them to the inventory list.
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);

        collider.enabled = false;
        renderer.enabled = false;
    }

}
