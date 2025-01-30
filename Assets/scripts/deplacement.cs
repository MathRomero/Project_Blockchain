using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    Animator animator;
    BoxCollider boxCollider;

    private bool IsGrounded;
    private bool canChangeLane = true;

    private int currentLane = 1;
    [SerializeField]
    private float laneWidth = 2f;
    private Vector3 OriginalSize;
    private Vector3 OriginalCenter;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float swipeThreshold = 50f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        OriginalCenter = boxCollider.center;
        OriginalSize = boxCollider.size;
    }

    private void Update()
    {
        DetectSwipe();
    }

    private void FixedUpdate()
    {
        float targetX = currentLane * laneWidth;
        Vector3 targetPosition = new Vector3(targetX - 1.25f, rb.position.y, rb.position.z);
        rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, Time.fixedDeltaTime * moveSpeed));

        IsGrounded = Mathf.Abs(rb.velocity.y) < 0.01f;
        animator.SetBool("IsJump", !IsGrounded);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            boxCollider.size = new Vector3(1, 1, 1);
            boxCollider.center = new Vector3(0, 0.5f, 0);
        }
        else
        {
            RestoreCollider();
        }
    }

    private void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                ProcessSwipe(endTouchPosition - startTouchPosition);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            ProcessSwipe(endTouchPosition - startTouchPosition);
        }
    }

    private void ProcessSwipe(Vector2 swipeDelta)
    {
        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > swipeThreshold && canChangeLane)
            {
                ChangeLane(1);
            }
            else if (swipeDelta.x < -swipeThreshold && canChangeLane)
            {
                ChangeLane(-1);
            }
        }
        else
        {
            if (swipeDelta.y > swipeThreshold && IsGrounded)
            {
                Jump();
            }
            else if (swipeDelta.y < -swipeThreshold && IsGrounded)
            {
                Roll();
            }
        }
    }

    private void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
        canChangeLane = false;
        Invoke("ResetLaneChange", 0.2f);
    }

    private void ResetLaneChange()
    {
        canChangeLane = true;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Roll()
    {
        animator.SetTrigger("Roll");
    }

    public void RestoreCollider()
    {
        boxCollider.size = OriginalSize;
        boxCollider.center = OriginalCenter;
    }
}
