using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 720f;
    private PlayerInputHandler _inputHandler;

    private void Start()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector2 direction = _inputHandler.MovementInput;
        Vector3 movement = new Vector3(direction.x, 0, direction.y) * _speed * Time.deltaTime;
        transform.position += movement;

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }   
    }
}
