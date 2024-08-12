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
        public string itemType = "";
        public Sprite ItemCover;
    }
    public ItemData itemData = new ItemData();
    
    public float MaxCap = 100f;
    public bool isAtMaxCap = false;
    [SerializeField] private TMP_Text quanityText;
    [SerializeField] private Image uiCoverImage;
    [SerializeField] private Image hotBarImage;

    /// <summary>
    /// Instaniates item to ui slot
    /// </summary>
    /// <param name="InputItemPrefab"></param>
    public void AddItemToSlot(InventoryItemData InputItemData)
    {           
        
        uiCoverImage.enabled = true;

        itemData.ItemCover = InputItemData.CoverImage;
        uiCoverImage.sprite = itemData.ItemCover;

        itemData.itemType = InputItemData.itemType;

        float Sum = InputItemData.quantity + itemData.quantity;
            
        // if sum is greater then max then run function in an empty slot
        if ( Sum > MaxCap){
            
            float addMore = MaxCap - itemData.quantity;
            itemData.quantity += addMore;
            InputItemData.quantity -= addMore;
            
            isAtMaxCap = true;

            if (InputItemData.quantity > 0f){
                InventoryBase.Instace.GetEmptySlot(InputItemData.itemType).AddItemToSlot(InputItemData);
            }
        }else if(Sum <= MaxCap){
            itemData.quantity += InputItemData.quantity;
        }

        quanityText.text = itemData.quantity.ToString() + "/100";

        if (itemData.quantity == MaxCap){
            isAtMaxCap = true;
        }
    }   

    public void ResetSlot(){
        itemData = new ItemData();

        uiCoverImage.enabled = false;
        isAtMaxCap = false;
        quanityText.text = "0/100";

    }
    

    public void AlphaSwap(bool isSelected){
        if (isSelected == true){
            var tempColor = hotBarImage.color;

            tempColor.a = 0.6078f;

            hotBarImage.color = tempColor;
        }else {
            var tempColor = hotBarImage.color;

            tempColor.a = 0.3922f;

            hotBarImage.color = tempColor;
        }
    }
}
