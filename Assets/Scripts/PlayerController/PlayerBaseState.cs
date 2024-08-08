
using UnityEngine;

public abstract class PlayerBaseState 
{
  public abstract void EnterState(PlayerStateManager player);

  public abstract void UpdateState(PlayerStateManager player);

  public abstract void OnCollisionEnterState(PlayerStateManager player, Collision collision);
  public abstract void OnTriggerEnterState(PlayerStateManager player, Collider collider);
}
