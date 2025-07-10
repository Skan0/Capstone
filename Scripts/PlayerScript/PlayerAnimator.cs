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
        //�⺻ �뽬 �ִϸ��̼�

    }
    public void AvoidDashAnim()
    {
        //�⺻ �뽬 �ִϸ��̼�
    }
}

