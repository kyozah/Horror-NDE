using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class TopDownPlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 moveInput;
    private bool isRunning;

    [Header("Flashlight")]
    public Light2D flashlight;               // Kéo Spot Light2D vào đây
    private bool hasFlashlight = false;      // Chỉ bật nếu đã nhặt đèn
    private bool flashlightOn = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (flashlight != null)
            flashlight.enabled = false; // Tắt sẵn
    }

    void Update()
    {
        // Di chuyển
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Animator
        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);

            // Cập nhật hướng đèn pin
            UpdateFlashlightDirection(moveInput);
        }

        // Bật/tắt flashlight
        if (hasFlashlight && Input.GetKeyDown(KeyCode.F))
        {
            flashlightOn = !flashlightOn;
            flashlight.enabled = flashlightOn;
        }
    }

    void FixedUpdate()
    {
        float speed = isRunning ? runSpeed : walkSpeed;
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    void UpdateFlashlightDirection(Vector2 direction)
    {
        if (flashlight != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            flashlight.transform.rotation = Quaternion.Euler(0, 0, angle - 90); // Trừ 90 để hướng theo Y
        }
    }

    public void EnableFlashlight()
    {
        hasFlashlight = true;
    }


}

