using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages Invetory slots
/// </summary>
public class InventoryBase : MonoBehaviour
{   

    

    // UI
        [SerializeField] private Canvas inventoryCanvas;
        public GameObject pickUpText;
        public GameObject merchantText;
        public TMP_Text balanceText;
        public float balance;
    // List
        public List<InventorySlot> inventorySlotList = new List<InventorySlot>();
        public List<InventorySlot> hotBarSlotList = new List<InventorySlot>();
    // Slot References
        public InventorySlot currentSlot;
        public int currentSlotID = 0;
    // Instance
        public static InventoryBase Instace;    

    
    
    private void Awake() {
        if (Instace == null){
            Instace = this;
        }else {
            Destroy(this);
        }
    }

    private void Start() {
        currentSlot = hotBarSlotList[currentSlotID];
        currentSlot.AlphaSwap(true);
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

    public void Sell(SellResources sellResources){
        if (currentSlot.itemData.itemType != ""){
            sellResources.Sell();
        }

        currentSlot.ResetSlot();
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

    private void Update() {
        balanceText.text = balance.ToString("C");
    }
}
