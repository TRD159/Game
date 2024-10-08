using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskedMischiefNamespace
{
  public class PlayerRunner : MonoBehaviour
  {
    [SerializeField] private float cameraDistance;
    private Transform cameraTransform;
    private PlayerMovementStateMachine movementStateMachine;
    public GameInput gameInput;


    private void Awake()
    {
      cameraTransform = Camera.main.transform;
      movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void Start()
    {
      movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void Update()
    {
      movementStateMachine.HandleInput();
      movementStateMachine.Update();
      cameraTransform.position = transform.position + transform.rotation * new Vector3(0, 0.75f, -(cameraDistance + 1));
      cameraTransform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position) * Quaternion.Euler(-5, 0, 0);
      cameraTransform.position += new Vector3(0, 1, 0);
    }

    private void FixedUpdate()
    {
      movementStateMachine.PhysicsUpdate();
    }
  }
}
