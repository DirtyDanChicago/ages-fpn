﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

/// <summary>
/// This script provides the connection to the player's inventory menu and the player's inventory list.
/// Includes debugs to make sure you only have on instance of the InventoryMenu script in the scene.
/// </summary>
public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;

    [Tooltip("Content of inventory item scroll view.")]
    [SerializeField]
    private Transform inventoryListContentArea;

    [Tooltip("Place in the UI for displaying the name of the selected inventory item.")]
    [SerializeField]
    private Text itemLabelText;

    [Tooltip("Place in the UI for displaying the description of the selected inventory item.")]
    [SerializeField]
    private Text itemDescriptionText;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private AudioSource inventoryOpen;

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
    
    private bool IsVisable => canvasGroup.alpha > 0;

    //Function for the exit button on the inventory menu UI.
    public void ExitButtonClicked()
    {
        HideMenu();
        inventoryOpen.Play();
    }

    /// <summary>
    /// Instantiates inventoryMenuItemToggle prefab and adds it to menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }

    //Shows the player's inventory menu.
    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //Hides the player's inventory menu.
    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
    }

    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        itemDescriptionText.text = inventoryObjectThatWasSelected.Description;
    }

    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }
    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }

    //Update handles inventory input.
    private void Update()
    {
        HandleInput();

    }

    //Player presses ShowInventoryMenu to show and hide menu.
    private void HandleInput()
    {
        if (Input.GetButtonDown("ShowInventoryMenu"))
            if (IsVisable)
            {
                HideMenu();
                inventoryOpen.Play();
            }
            else
            {
                ShowMenu();
                inventoryOpen.Play();
            }
                
    }

    //Looks for instances of the InventoryMenu script, throws exception of there is more than one. It also gets the components needed.
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
           throw new System.Exception("There is already an instance of InventoryMenu, there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        inventoryOpen = GetComponent<AudioSource>();
    }

    private void Start()
    {
        HideMenu();
    }
}
