using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Invetory slots
/// </summary>
public class InventoryBase : MonoBehaviour
{   
    public List<InventorySlot> inventorySlotList = new List<InventorySlot>();

    public InventorySlot currentlySelectedSlot;

    public static InventoryBase Instace;
    
    private void Awake() {
        if (Instace == null){
            Instace = this;
        }else {
            Destroy(this);
        }
    }

    public void AddToSlot(GameObject itemPrefab){
        // Debug.Log(itemPrefab.gameObject.name);

        currentlySelectedSlot.AddItemToSlot(itemPrefab);
    }

    public void PickUp(InventoryItemPickUp PickUpPrefab){

        GetEmptySlot().AddItemToSlot(PickUpPrefab.InvetoryPrefab);
        Destroy(PickUpPrefab.gameObject);
    }

    public InventorySlot GetEmptySlot()
    {
        foreach (InventorySlot slot in inventorySlotList){
            if (slot.currentItem == null){
                return slot;
            }
        }
        return null;
    }


}
