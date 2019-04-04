using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    //TODO: Add long description field.
    //TODO: Add a field for an icon.

    [Tooltip("The name of the object as it appears in the player's inventory.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("This is the description of the inventory object.")]
    [TextArea(3, 8)]
    [SerializeField]
    private string itemDescription;

    [Tooltip("Inventory object's icon.")]
    [SerializeField]
    private Sprite itemIcon;

    public string ObjectName => objectName;

    //Variables to help find the collider, and renderer of the Inventory Objects.
    private new Collider collider;
    private new Renderer renderer;

    private void Start()
    {
        //Initialize the components.
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
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
