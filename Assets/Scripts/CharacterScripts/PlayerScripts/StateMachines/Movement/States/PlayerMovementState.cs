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
    protected float baseSpeed = 5f;
    protected float speedModifier = 1f;
    protected bool jumpInput;

    public PlayerMovementState(PlayerMovementStateMachine playermovementstatemachine)
    {
      stateMachine = playermovementstatemachine;
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

    public virtual void HandleInput()
    {
      ReadInputs();
    }
    public virtual void Update() { }
    public virtual void PhysicsUpdate()
    {
      Move();
    }

    private void ReadInputs()
    {
      GameInput input = stateMachine.playerRunner.gameInput;

      movementInput = input.getMovementInputVectorNormalized();
      jumpInput = input.getJumpInput();
    }

    private void Move()
    {
      if (movementInput == Vector2.zero)
      {
        return;
      }
    }

    protected virtual void AddCallbacks() { }

    protected virtual void RemoveCallbacks() { }
  }
}
