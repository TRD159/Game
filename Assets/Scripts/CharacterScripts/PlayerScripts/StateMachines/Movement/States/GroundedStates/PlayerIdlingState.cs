using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskedMischiefNamespace
{
  public class PlayerIdlingState : PlayerGroundedState
  {
    public PlayerIdlingState(PlayerMovementStateMachine m) : base(m)
    {
    }

    public override void HandleInput()
    {
      base.HandleInput();
      if (jumpInput)
      {
        stateMachine.ChangeState(stateMachine.JumpingState);
      }
    }
  }
}
