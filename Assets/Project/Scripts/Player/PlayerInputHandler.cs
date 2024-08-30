using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private PlayerForce _forceStart;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _forceStart = GetComponent<PlayerForce>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _playerMovement.Move(_moveAction.ReadValue<Vector2>());
        ForceAbillityCheck();
    }

    private void ForceAbillityCheck()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _forceStart.ForceAbility();
        }
    }
}
