using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpState : PlayerBaseState
{
  private Rigidbody rb;
  public override void EnterState(PlayerStateManager player){
    Cursor.lockState = CursorLockMode.Locked;

    rb = player.rb;

    Debug.Log("PickUp Entered");
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
          Debug.Log("Pick Up");
        
        if (Input.GetKeyDown(KeyCode.E))
        { 

          InventoryBase.Instace.PickUp(hit.collider.gameObject.GetComponent<InventoryItemPickUp>());
          Debug.Log("Cube Picked Up");

        }
      }
      else 
      {
          InventoryBase.Instace.pickUpText.SetActive(false);
      }
    }
  }


  public override void UpdateState(PlayerStateManager player)
  {
   PickUp(player);
   Look(player);
   Walk();

   if (Input.GetKeyDown(KeyCode.I)){
    player.SwitchState(player._playerInventoryState);
   }
  }
  
  public override void OnCollisionEnterState(PlayerStateManager player, Collision collision){
    
  }
  public override void OnTriggerEnterState(PlayerStateManager player, Collider collider){

  }
}