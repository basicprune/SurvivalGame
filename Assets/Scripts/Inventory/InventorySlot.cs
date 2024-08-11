using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Shows Inventory Items on the ui
/// </summary>
public class InventorySlot : MonoBehaviour
{
    public InvetoryItemPrefab currentItem;
    [SerializeField] private GameObject itemObject;
    [SerializeField] private TMP_Text quanityText;

    /// <summary>
    /// Instaniates item to ui slot
    /// </summary>
    /// <param name="InputItemPrefab"></param>
    public void AddItemToSlot(GameObject InputItemPrefab)
    {   
        InvetoryItemPrefab InputItem = InputItemPrefab.gameObject.GetComponent<InvetoryItemPrefab>();
        InventoryBase.Instace.inventoryItemPrefabs.Add(InputItem);

        if (currentItem == null){
            currentItem = InputItem;
            Instantiate(InputItem, gameObject.transform);
            
            // currentItem.gameObject.transform.SetParent(this.gameObject.transform);
        }
        else if(currentItem.itemType == InputItem.itemType)
        {   
            // type is basically wood,iron ETC
            currentItem.AddItemQuantity(InputItem.inventoryItemData.quantity);
        }

        // Set quantity text
        quanityText.text = currentItem.inventoryItemData.quantity.ToString() + "/100";
    }   

    public void SetSelected()
    {
        InventoryBase.Instace.currentlySelectedSlot = gameObject.GetComponent<InventorySlot>();
    }

}
