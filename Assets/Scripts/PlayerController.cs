using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public InputAction playerMovement;
    private Vector2 moveDirection;
    public int moveForce = 50;


    void Start()
    {
        
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
    }

    
    void Update()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        playerRigidbody.AddForceX(moveDirection.x * moveForce);
        playerRigidbody.AddForceY(moveDirection.y * moveForce);
        //add coroutine here so only move once per second
    }

}
