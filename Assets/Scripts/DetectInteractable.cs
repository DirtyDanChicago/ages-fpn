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
        raycastDirection = raycastOrigin.forward;
        Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, maxDistance);
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDistance, Color.red);
    }



}
