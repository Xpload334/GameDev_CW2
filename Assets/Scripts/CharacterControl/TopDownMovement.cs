using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    public float speed = 5f;
    public InputAction moveAction;

    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 targetVelocity;
    [SerializeField] private float movementSmoothing = 0.05f;
    private Vector2 _mVelocity;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        targetVelocity = moveInput * speed;
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref _mVelocity, movementSmoothing);
    }
}
