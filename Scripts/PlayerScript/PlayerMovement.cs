using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastInputDir;
    private bool isOverriding = false;
    private float moveSpeed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        if (isOverriding) return; // 대쉬 중이면 무시
   
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 inputDir = new Vector3(direction.x, 0, direction.y).normalized;
            lastInputDir = inputDir;
            rb.linearVelocity = new Vector3(inputDir.x, rb.linearVelocity.y, inputDir.z) * moveSpeed;
        }
        else
        {
            // 입력이 없으면 수평 속도만 0으로
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

public void ForceMove(Vector3 dir, float force)
    {
        rb.linearVelocity = dir.normalized * force;
        isOverriding = true;
        Invoke(nameof(ResetOverride), 0.1f); // 0.1초 후 이동 제어 재개
    }

    private void ResetOverride()
    {
        isOverriding = false;
    }

    public Vector3 GetLastMoveDirection()
    {
        return lastInputDir;
    }
}
