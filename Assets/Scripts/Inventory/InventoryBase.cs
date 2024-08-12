using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Invetory slots
/// </summary>
public class InventoryBase : MonoBehaviour
{   

    

    // UI
    [SerializeField] private Canvas inventoryCanvas;
    public GameObject pickUpText;
    // List
    public List<InventorySlot> inventorySlotList = new List<InventorySlot>();
    // Instance
    public static InventoryBase Instace;
    
    private void Awake() {
        if (Instace == null){
            Instace = this;
        }else {
            Destroy(this);
        }
    }
    public void ToggleInvetory(){
        if (inventoryCanvas.enabled == true){
            inventoryCanvas.enabled = false;
        }
        else{
            inventoryCanvas.enabled = true;
        }
    }

    public void PickUp(InventoryItemData PickedUpItemData){
        GetEmptySlot(PickedUpItemData.itemType).AddItemToSlot(PickedUpItemData);
        Destroy(PickedUpItemData.gameObject);
    }

    public InventorySlot GetEmptySlot(string itemType)
    {
        foreach (InventorySlot slot in inventorySlotList){
            if (slot.isAtMaxCap == false){
                if (slot.itemData.itemType == itemType || slot.itemData.itemType == ""){
                    return slot;
                }
                // return slot;
            }
        }
        return null;
    }
}
