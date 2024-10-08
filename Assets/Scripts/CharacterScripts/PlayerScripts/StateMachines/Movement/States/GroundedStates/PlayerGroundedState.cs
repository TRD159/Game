using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MaskedMischiefNamespace
{
  public class PlayerGroundedState : PlayerMovementState
  {
    public PlayerGroundedState(PlayerMovementStateMachine m) : base(m)
    {
      
    }
    
    protected override void AddCallbacks()
    {      
      stateMachine.playerRunner.gameInput.playerActions.Jump.started += OnJump;
    }
    
    protected override void RemoveCallbacks()
    {
      stateMachine.playerRunner.gameInput.playerActions.Jump.started -= OnJump;
    }
    
    public override void Enter()
    {
      base.Enter();
      AddCallbacks();
    }
    public override void Exit()
    {
      base.Exit();
      RemoveCallbacks();
    }
    
    public override void PhysicsUpdate()
    {
      base.PhysicsUpdate();
      
      Rigidbody r = stateMachine.playerRunner.GetComponentInChildren<Rigidbody>();
      
      if(!Physics.Raycast(r.transform.position + (Vector3.up * 0.25f), Vector3.down, 0.35f))
      {
        stateMachine.ChangeState(stateMachine.FallingState);
      }
    }
    
    public void OnJump(InputAction.CallbackContext c)
    {
      stateMachine.ChangeState(stateMachine.JumpingState);
    }    
  }
}
