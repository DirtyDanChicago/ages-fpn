﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DetectInteractable : MonoBehaviour
{
    /// <summary>
    /// This script detects the interactable elements the player is looking at.
    /// 
    /// Raycasting Reference:
    /// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    /// </summary>

    [Tooltip ("Starting point of the raycast.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("This is the maximum distance the raycast can detect interactables.")]
    [SerializeField]
    private float maxDistance = 5.0f;

    private Vector3 raycastDirection;

    /// <summary>
    /// An event that is activated when a player looks at an new interactable object.
    /// </summary>

    public static event Action <IInteractive> LookedAtInteractiveChanged;
    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != LookedAtInteractive;

            if (isInteractiveChanged)

                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
        }
    }

    public IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
       LookedAtInteractive = GetLookedAtInteractive();
    }

    /// <summary>
    /// Raycasts from the camera to detect IInteractive objects.
    /// </summary>
    /// <returns> Returns the first IInteractive detected, or returning null if no IInteractives are found.</returns>
    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDistance, Color.red);
        RaycastHit hitInfo;

        bool objectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDistance);

        IInteractive interactive = null;

        lookedAtInteractive = interactive;

        if (objectDetected)
        {
            //Debug to test the raycast.
            //Debug.Log($"The player is looking at {hitInfo.collider.gameObject.name}");

            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        //If the interactive object isn't null the object is interactable.
        if (interactive != null)
        {
            lookedAtInteractive = interactive;
        }

        return interactive;
    }
}
