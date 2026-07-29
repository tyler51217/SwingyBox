using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private Vector2 moveDirection;
    public int moveForce = 10;
    private bool attacking = false;
    public InputActionAsset inputActions;
    public Camera mainCam;
    public LineRenderer lr;

    private InputAction moveAction;
    private InputAction attackAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    

    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();

        if (attackAction.ReadValue<float>() == 1)
            attacking = true;
        else
            attacking = false;
    }
    private void FixedUpdate()
    {
        playerRigidbody.AddForceX(moveDirection.x * moveForce, ForceMode2D.Impulse);
        playerRigidbody.AddForceY(moveDirection.y * moveForce, ForceMode2D.Impulse);
        //add coroutine here so only move once per second

        if (attacking)
        {
            //draw line from player to mouse

            lr.enabled = true;
            lr.startWidth = 0.3f;
            lr.endWidth = 0.3f;
            lr.positionCount = 2;
            lr.startColor = Color.white;
            lr.endColor = Color.white;
            lr.SetPosition(0, playerRigidbody.position);
            lr.SetPosition(1, mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()));

            
        }
    }

}
