using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellResources : MonoBehaviour
{
    // Each Resource has a different value

    // switch to enum? or some sort of Dictionary
    public float woodPrice = 1f;
    public float rockPrice = 1f;

    public void Sell(){
        if (InventoryBase.Instace.currentSlot.itemData.itemType == "Wood"){
            InventoryBase.Instace.balance += InventoryBase.Instace.currentSlot.itemData.quantity * woodPrice;
        }else if(InventoryBase.Instace.currentSlot.itemData.itemType == "Rock"){
            InventoryBase.Instace.balance += InventoryBase.Instace.currentSlot.itemData.quantity * rockPrice;
        }
    }

}
