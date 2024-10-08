using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskedMischiefNamespace
{
  public class PlayerMovementStateMachine : StateMachine
  {
    public PlayerRunner playerRunner;
    
    public PlayerIdlingState IdlingState { get; }
    public PlayerWalkingState WalkingState { get; }
    public PlayerRunningState RunningState { get; }
    public PlayerFallingState FallingState { get; }
    public PlayerJumpingState JumpingState { get; }
    

    public PlayerMovementStateMachine(PlayerRunner player)
    {
      playerRunner = player;
      
      IdlingState = new PlayerIdlingState(this);
      WalkingState = new PlayerWalkingState(this);
      RunningState = new PlayerRunningState(this);
      FallingState = new PlayerFallingState(this);
      JumpingState = new PlayerJumpingState(this);
    }
  }
}
