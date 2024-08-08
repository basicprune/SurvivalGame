using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Invetory slots
/// </summary>
public class InventoryBase : MonoBehaviour
{   
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


}
