using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 400;
    [SerializeField] private Vector3 moveInput;
    private Rigidbody rb;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    void Update()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector3>();
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.z);

    }
}