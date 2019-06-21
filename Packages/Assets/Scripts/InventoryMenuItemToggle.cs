using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("The image component used to show the object's icon.")]
    [SerializeField]
    private Image iconImage;

    public static event Action<InventoryObject> InventoryMenuItemSelected;

    private InventoryObject associatedInventoryObject;
    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    /// <summary>
    /// This plugs into the OnValueChanged property in the editor
    /// and called whenever the toggle is clicked on.
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        //We only want to do the stuff when the toggle has been selected. But not when it's been de-selected.
        if (isOn)
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        Debug.Log($"Toggled: {isOn}");
    }

    //On awake, get the toggle and toggle group components.
    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
}
