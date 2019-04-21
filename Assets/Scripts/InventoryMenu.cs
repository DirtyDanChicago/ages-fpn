using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// This script provides the connection to the player's inventory menu and the player's inventory list.
/// Includes debugs to make sure you only have on instance of the InventoryMenu script in the scene.
/// </summary>
public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;

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

    //Shows the player's inventory menu.
    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        
    }

    //Hides the player's inventory menu.
    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void Update()
    {
        HandleInput();

    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("ShowInventoryMenu"))
            if (IsVisable)
                HideMenu();
            else
                ShowMenu();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
           throw new System.Exception("There is already an instance of InventoryMenu, there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
    }
}
