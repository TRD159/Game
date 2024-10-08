using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

  public PlayerInputActions playerInputActions { get; private set; }
  public PlayerInputActions.PlayerActions playerActions { get; private set; }

  private void Awake()
  {
    playerInputActions = new PlayerInputActions();
    playerActions = playerInputActions.Player;
    playerInputActions.Player.Enable();
  }

  public bool getJumpInput()
  {
    if (playerActions.Jump.ReadValue<float>() == 1)
    {
      return true;
    }
    return false;
  }

  public bool getSprintInput()
  {
    if (playerActions.Sprint.ReadValue<float>() == 1)
      return true;
    return false;
  }


  public Vector2 getMovementInputVectorNormalized()
  {
    Vector2 movementInput = playerActions.Move.ReadValue<Vector2>();
    /*
     if(movementInput.y == 0)
     {
         movementInput.x = 0;
     }*/

    /*if (movementInput.y < 0)
    {
        movementInput.x *= -1;
    }*/

    movementInput = movementInput.normalized;

    return movementInput;
  }

  private void OnEnable()
  {
    playerInputActions.Enable();
  }
  private void OnDisable()
  {
    playerInputActions.Disable();
  }
}
