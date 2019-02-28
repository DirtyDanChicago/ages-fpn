using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDistance, Color.red);
        RaycastHit hitInfo;

        bool objectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxDistance);

        IInteractive interactive = null; 

        if (objectDetected)
        {
            //Debug.Log($"The player is looking at {hitInfo.collider.gameObject.name}");

            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        if (interactive != null)
        {
            interactive.InteractWith();
        }

    }

}
