using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerToolState : PlayerBaseState
{
  private Rigidbody rb;
  public override void EnterState(PlayerStateManager player){
    Cursor.lockState = CursorLockMode.Locked;

    rb = player.rb;

    Debug.Log("Tool Entered");
  }

  public void Walk()
  {
    if (Input.GetKey(KeyCode.W))
    {
      rb.velocity = rb.transform.forward * 15f;
    }
    else if(Input.GetKey(KeyCode.S)){
      rb.velocity = -rb.transform.forward * 12f;
    }
    if(Input.GetKey(KeyCode.A)){
      rb.velocity = -rb.transform.right * 12f;
    }
    else if(Input.GetKey(KeyCode.D)){
      rb.velocity = rb.transform.right * 12f;
    }
  }

  //
  float mouseSen = 2f;
  float camVrotation = 0f;
  public void Look(PlayerStateManager player)
  {
    

    float inputX = Input.GetAxis("Mouse X")*mouseSen;
    float inputY = Input.GetAxis("Mouse Y")*mouseSen;

    
    camVrotation -= inputY;
    camVrotation = Mathf.Clamp(camVrotation, -90f, 90f);
    player.cam.transform.localEulerAngles = Vector3.right * camVrotation;

    player.capsule.transform.Rotate(Vector3.up * inputX);

	}

  public void PickUp(PlayerStateManager player)
  {
    RaycastHit hit;

    if (Physics.Raycast(player.cam.transform.position, player.cam.transform.forward, out hit, 50f))
    {
      if (hit.collider.tag == "PickUp")
      {
        //
          // Add ui popup to show you can pick up
          InventoryBase.Instace.pickUpText.SetActive(true);
          // Debug.Log("Pick Up");
        
        if (Input.GetKeyDown(KeyCode.E))
        { 

          InventoryBase.Instace.PickUp(hit.collider.gameObject.GetComponent<InventoryItemData>());
          Debug.Log("Cube Picked Up");

        }
      }
      else 
      {
          InventoryBase.Instace.pickUpText.SetActive(false);
      }

      if (hit.collider.tag == "Node"){
        if (Input.GetMouseButtonDown(0))
        hit.collider.GetComponent<ResourceNode>().HitNode(25f);
      }

      if (hit.collider.tag == "Merchant"){
        InventoryBase.Instace.merchantText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        { 

          InventoryBase.Instace.Sell(hit.collider.gameObject.GetComponent<SellResources>());
          Debug.Log("Sell Pressed");

        }

      }else{
        InventoryBase.Instace.merchantText.SetActive(false);

      }
    }
  }

  public void ScrollHotBar(){
    if (Input.GetAxis("Mouse ScrollWheel") > 0f ){
      InventoryBase.Instace.currentSlot.AlphaSwap(false);

      if (InventoryBase.Instace.currentSlotID == 0){

        InventoryBase.Instace.currentSlotID = 6;
        InventoryBase.Instace.currentSlot = InventoryBase.Instace.hotBarSlotList[InventoryBase.Instace.currentSlotID];
        
      }else {
        
        InventoryBase.Instace.currentSlotID -= 1;
        InventoryBase.Instace.currentSlot = InventoryBase.Instace.hotBarSlotList[InventoryBase.Instace.currentSlotID];
        
      }
      InventoryBase.Instace.currentSlot.AlphaSwap(true);
    }
    else if (Input.GetAxis("Mouse ScrollWheel") < 0f){
      InventoryBase.Instace.currentSlot.AlphaSwap(false);
      
      if (InventoryBase.Instace.currentSlotID == 6)
      {
        InventoryBase.Instace.currentSlotID = 0;
        InventoryBase.Instace.currentSlot = InventoryBase.Instace.hotBarSlotList[InventoryBase.Instace.currentSlotID];
      }
      else 
      {
        InventoryBase.Instace.currentSlotID += 1;
        InventoryBase.Instace.currentSlot = InventoryBase.Instace.hotBarSlotList[InventoryBase.Instace.currentSlotID];
      }
      InventoryBase.Instace.currentSlot.AlphaSwap(true);

    }


  }



  public override void UpdateState(PlayerStateManager player)
  {
   ScrollHotBar();
   PickUp(player);
   Look(player);
   Walk();

   if (Input.GetKeyDown(KeyCode.I)){
    player.SwitchState(player._playerUIState);
   }
  }
  
  public override void OnCollisionEnterState(PlayerStateManager player, Collision collision){
    
  }
  public override void OnTriggerEnterState(PlayerStateManager player, Collider collider){

  }
}