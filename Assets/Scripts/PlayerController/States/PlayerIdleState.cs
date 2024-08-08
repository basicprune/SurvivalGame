using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
  public override void EnterState(PlayerStateManager player){

  }

  public override void UpdateState(PlayerStateManager player)
  {
    if (Input.GetKeyDown(KeyCode.F)){
        player.SwitchState(player._playerWalkState);
    }
  }

  public override void OnCollisionEnterState(PlayerStateManager player, Collision collision){
    
  }
  public override void OnTriggerEnterState(PlayerStateManager player, Collider collider){

  }
}