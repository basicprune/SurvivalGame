using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Added to InvetorySlot's, Aswell as holds InvetoryItemData
/// </summary>
public class InvetoryItemPrefab : MonoBehaviour
{
    public InventoryItemData inventoryItemData;
    public string itemType;

    private void Awake() {
        inventoryItemData.itemType = itemType;
    }

    /// <summary>
    /// Add quantity to IventoryItemData
    /// </summary>
    /// <param name="itemQuantity"></param>
    public void AddItemQuantity(float itemQuantity){
        if (inventoryItemData.quantity + itemQuantity <= 100f){
            inventoryItemData.quantity += itemQuantity;
        }
    }
}
