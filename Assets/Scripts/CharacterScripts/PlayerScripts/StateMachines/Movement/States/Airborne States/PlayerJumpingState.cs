using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskedMischiefNamespace
{
    public class PlayerJumpingState : PlayerAirborneState
    {
      public PlayerJumpingState(PlayerMovementStateMachine m) : base(m)
      {
      }
      
      public override void Enter()
      {
        base.Enter();
        stateMachine.playerRunner.yVelocity = 0.05f;
      }
      
      public override void PhysicsUpdate()
      {
        base.PhysicsUpdate();
      
        PlayerRunner p = stateMachine.playerRunner;
        //Rigidbody r = stateMachine.playerRunner.GetComponentInChildren<Rigidbody>();
        
        if(!Physics.Raycast(p.transform.position + (Vector3.up * 0.25f), Vector3.down, 0.35f))
        {
          stateMachine.ChangeState(stateMachine.FallingState);
        }
        else
        {
          p.transform.Translate(0, p.yVelocity, 0);
          p.yVelocity -= p.gravity;
        }
      }
    }
}
