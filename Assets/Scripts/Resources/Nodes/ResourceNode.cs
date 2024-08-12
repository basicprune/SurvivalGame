using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    [SerializeField] private float HP;
    public InventoryItemData itemData;

    public void HitNode(float damage){
        HP -= damage;

        if (HP <= 0f){
            InventoryBase.Instace.PickUp(itemData);
        }
    }


}
