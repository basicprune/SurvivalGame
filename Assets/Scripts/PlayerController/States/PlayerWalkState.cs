using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
  public override void EnterState(PlayerStateManager player){

  }

  public void Walk()
  {
    if (Input.GetKeyDown(KeyCode.W))
    {
      
    }
  }








  public override void UpdateState(PlayerStateManager player)
  {
    // if (Input.GetKeyDown(KeyCode.F)){
    //     player.SwitchState(player.);
    // }
  }
  
  public override void OnCollisionEnterState(PlayerStateManager player, Collision collision){
    
  }
  public override void OnTriggerEnterState(PlayerStateManager player, Collider collider){

  }
}