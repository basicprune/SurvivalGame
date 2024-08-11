using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // public Player

    public Rigidbody rb;
    public GameObject capsule;
    public GameObject cam;

    public PlayerBaseState _currentState;
    public PlayerWalkState _playerWalkState = new PlayerWalkState();
    public PlayerIdleState _playerIdleState = new PlayerIdleState();
    public PlayerPickUpState _playerPickUpState = new PlayerPickUpState();
    

        // Start is called before the first frame update
    void Start()
    {
        _currentState = _playerPickUpState;

        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }
    void OnCollisionEnterState(Collision collision) {
        _currentState.OnCollisionEnterState(this, collision);
    }

    public void OnTriggerEnterState(Collider collider) {
        _currentState.OnTriggerEnterState(this, collider);
    }

    public void SwitchState(PlayerBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
}
