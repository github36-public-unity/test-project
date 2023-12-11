using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float playerRunSpeed = 5f;
    private Rigidbody2D rb;

    // ¡ÀŒ  —»—“≈Ã€ ¬¬Œƒ¿
    private InputSystem inputSystem;
    private void OnEnable()
    {
        inputSystem.Enable();
    }
    private void OnDisable()
    {
        inputSystem.Disable();
    }

    private void Awake()
    {
        inputSystem = new InputSystem();
        inputSystem.Main.MoveX.performed += MoveX_performed;
        inputSystem.Main.MoveX.canceled += MoveX_canceled;
    }




    // MoveX
    private void MoveX_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        float value = obj.ReadValue<float>();
        horizontalInput = value;
    }

    private void MoveX_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        float value = obj.ReadValue<float>();
        horizontalInput = value;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


        void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput * playerRunSpeed, rb.velocity.y);
        rb.velocity = movement;
    }








}
