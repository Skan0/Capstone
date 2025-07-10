using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(Vector2 movement)
    {
        bool isMoving = movement.magnitude > 0.1f;
        animator.SetBool("IsMoving",isMoving);
    }
    
    public void BasicDashAnim()
    {
        //기본 대쉬 애니메이션

    }
    public void AvoidDashAnim()
    {
        //기본 대쉬 애니메이션
    }
}

