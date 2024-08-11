using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
  private Rigidbody rb;
  public override void EnterState(PlayerStateManager player){
    Cursor.lockState = CursorLockMode.Locked;

    rb = player.rb;

    Debug.Log("WalkState Entered");
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


  public override void UpdateState(PlayerStateManager player)
  {
   Look(player);
   Walk();
  }
  
  public override void OnCollisionEnterState(PlayerStateManager player, Collision collision){
    
  }
  public override void OnTriggerEnterState(PlayerStateManager player, Collider collider){

  }
}