using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MaskedMischiefNamespace
{
  public class PlayerMovementState : IState
  {
    protected PlayerMovementStateMachine stateMachine;
    
    protected Vector2 movementInput;
    protected bool jumpInput;
    
    public PlayerMovementState(PlayerMovementStateMachine m)
    {
      stateMachine = m;
    }
    
    public virtual void Enter()
    {
      Debug.Log("Entering State: " + GetType().Name);
      AddCallbacks();
    }
    public virtual void Exit()
    {
      Debug.Log("Exiting State: " + GetType().Name);
      RemoveCallbacks();
    }

    public virtual void HandleInput() { }
    public virtual void Update() { }
    public virtual void PhysicsUpdate() { }
    
    private void ReadInputs()
    {
      GameInput input = stateMachine.playerRunner.gameInput;
      
      movementInput = input.getMovementInputVectorNormalized();
      jumpInput = input.getJumpInput();
    }
    
    protected virtual void AddCallbacks() {}
    
    protected virtual void RemoveCallbacks() {}
  }
}
