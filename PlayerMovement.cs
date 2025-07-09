using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        Vector3 currentVelocity = rb.linearVelocity; 
        rb.linearVelocity = new Vector3(direction.x * moveSpeed, currentVelocity.y, direction.y * moveSpeed);
    }
}