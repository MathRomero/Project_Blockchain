using UnityEngine;
using UnityEngine.InputSystem;

public class Deplacement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    Animator animator;

    private bool IsGrounded;
    private bool canChangeLane;
   
    private int currentLane = 1;
    [SerializeField]
    public float laneWidth = 2f;


    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference roll;

    private void Start()
    {
         animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
        Vector2 input = move.action.ReadValue<Vector2>();
        if (canChangeLane && input.x > 0.5f) 
        {
            ChangeLane(1);
        }
        else if (canChangeLane && input.x < -0.5f) 
        {
            ChangeLane(-1);
        }
        if (Mathf.Abs(input.x) < 0.5f)
        {
            canChangeLane = true; 
        }
       
    }

    private void FixedUpdate()
    {

        float targetX = currentLane * laneWidth; 
        Vector3 targetPosition = new Vector3(targetX, rb.position.y, rb.position.z);

        rb.MovePosition(targetPosition);
        IsGrounded = Mathf.Abs(rb.velocity.y) < 0.01f;
        if (IsGrounded)
        {
            animator.SetBool("IsJump", false);


        }
        else
        {
            animator.SetBool("IsJump", true);
        }



    }


    private void ChangeLane(int direction)
    {
        
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
        canChangeLane = false;
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           
        }
      
    }
    private void Roll(InputAction.CallbackContext obj)
    {
        if (IsGrounded) 
        {
            animator.SetTrigger("Roll");
            
        }
    }
   

    private void OnEnable()
    {
        
        jump.action.started += Jump;
        roll.action.started += Roll;

    }

    private void OnDisable()
    {
        
        jump.action.started -= Jump;
        roll.action.started -= Roll;

    }

}
