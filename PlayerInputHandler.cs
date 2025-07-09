using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        return new Vector2(h, v).normalized;
    }
    public bool IsLeftClickPressed()
    {
        return Input.GetMouseButtonDown(0);// ����
    }
    public bool IsRightClickPressed()
    {
        return Input.GetMouseButtonDown(1);// ���&&ȸ��
    }

    // ����, ��� ���� �Է� �޼��嵵 �߰� ����
}