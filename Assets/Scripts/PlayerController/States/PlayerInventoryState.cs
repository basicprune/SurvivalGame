using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryState : PlayerBaseState
{
  public override void EnterState(PlayerStateManager player){
    Cursor.lockState = CursorLockMode.None;
    InventoryBase.Instace.ToggleInvetory();
        
  }

  public override void UpdateState(PlayerStateManager player)
  {
    if (Input.GetKeyDown(KeyCode.I)){
      InventoryBase.Instace.ToggleInvetory();
      player.SwitchState(player._playerPickUpState);
    }
  }

  public override void OnCollisionEnterState(PlayerStateManager player, Collision collision){
    
  }
  public override void OnTriggerEnterState(PlayerStateManager player, Collider collider){

  }
}