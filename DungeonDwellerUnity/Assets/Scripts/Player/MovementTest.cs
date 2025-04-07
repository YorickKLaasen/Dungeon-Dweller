using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float moveSpeed = 5f; // Snelheid van de speler
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input van speler (WASD, pijltjestoetsen of joystick)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize zodat diagonale beweging niet sneller is
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // Speler bewegen via Rigidbody2D physics
        rb.linearVelocity = movement * moveSpeed;
    }
}
