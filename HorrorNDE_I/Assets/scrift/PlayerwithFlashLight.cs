using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerWithFlashlight : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;

    [Header("Flashlight")]
    public Light2D flashlight; // Assign your child Light2D (Spot)
    public KeyCode toggleKey = KeyCode.F;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private bool isRunning;

    private static PlayerWithFlashlight instance;

    void Awake()
    {
        // Persist player across scenes
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (flashlight != null)
            flashlight.enabled = false; // Start off
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Toggle flashlight
        if (Input.GetKeyDown(toggleKey) && flashlight != null)
        {
            flashlight.enabled = !flashlight.enabled;
        }

        // Animator
        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);

            RotateFlashlight(moveInput);
        }
    }

    void FixedUpdate()
    {
        float speed = isRunning ? runSpeed : walkSpeed;
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    void RotateFlashlight(Vector2 direction)
    {
        if (flashlight == null) return;

        // Only rotate if there is input
        if (direction.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            flashlight.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
}
