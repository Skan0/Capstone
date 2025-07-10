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
        if (isOverriding) return; // �뽬 ���̸� ����
   
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 inputDir = new Vector3(direction.x, 0, direction.y).normalized;
            lastInputDir = inputDir;
            rb.linearVelocity = new Vector3(inputDir.x, rb.linearVelocity.y, inputDir.z) * moveSpeed;
        }
        else
        {
            // �Է��� ������ ���� �ӵ��� 0����
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

public void ForceMove(Vector3 dir, float force)
    {
        rb.linearVelocity = dir.normalized * force;
        isOverriding = true;
        Invoke(nameof(ResetOverride), 0.1f); // 0.1�� �� �̵� ���� �簳
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
