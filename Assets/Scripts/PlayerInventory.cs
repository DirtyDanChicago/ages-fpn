using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static List<InventoryObject> InventoryObjects { get; } = new List<InventoryObject>();
    public static object InventoryObject { get; internal set; }
}
