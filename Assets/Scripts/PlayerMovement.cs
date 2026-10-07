using UnityEngine;
    
public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    private InputActions actions;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;

    private void Awake()
    {
        actions = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        ReadMovement();
        if (moveDirection == Vector2.zero)
        {
            animator.SetBool("Moving", false);
            return;
        }
        animator.SetBool("Moving", true);
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", moveDirection.y);
    }
}
