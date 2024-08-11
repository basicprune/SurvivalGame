using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows Inventory Items on the ui
/// </summary>
public class InventorySlot : MonoBehaviour
{   

    [System.Serializable]
    public class ItemData{
        public float quantity;
        public string itemType;
        public Sprite ItemCover;
    }
    public ItemData itemData = new ItemData();
    
    public bool InUse = false;
    [SerializeField] private GameObject itemObject;
    [SerializeField] private TMP_Text quanityText;
    [SerializeField] private Image uiCoverImage;

    /// <summary>
    /// Instaniates item to ui slot
    /// </summary>
    /// <param name="InputItemPrefab"></param>
    public void AddItemToSlot(InventoryItemData InputItemData)
    {   
        
        if (InputItemData.quantity + itemData.quantity <= 100f){
            
            uiCoverImage.enabled = true;

            itemData.ItemCover = InputItemData.CoverImage;
            uiCoverImage.sprite = itemData.ItemCover;

            itemData.itemType = InputItemData.itemType;

            itemData.quantity += InputItemData.quantity;
            quanityText.text = itemData.quantity.ToString();
        }else if (InputItemData.quantity + itemData.quantity > 100f){
            InventoryBase.Instace.GetEmptySlot().AddItemToSlot(InputItemData);
        }

    }   
}
