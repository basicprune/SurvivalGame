using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Invetory slots
/// </summary>
public class InventoryBase : MonoBehaviour
{   
    [SerializeField] private Canvas inventoryCanvas;
    public GameObject pickUpText;
    public List<InventorySlot> inventorySlotList = new List<InventorySlot>();
    public List<InvetoryItemPrefab> inventoryItemPrefabs = new List<InvetoryItemPrefab>();

    public InventorySlot currentlySelectedSlot;

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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)){
            ToggleInvetory();
        }
    }


}
