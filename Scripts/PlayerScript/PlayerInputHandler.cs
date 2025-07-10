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
        return Input.GetMouseButtonDown(0);// 공격
    }
    public bool IsRightClickPressed()
    {
        return Input.GetMouseButtonDown(1);// 대시&&회피
    }

    // 점프, 대시 같은 입력 메서드도 추가 가능
}