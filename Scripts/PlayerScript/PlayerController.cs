using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform weaponHolder;


    private PlayerInputHandler input;
    private PlayerMovement movement;
    private PlayerAnimator animator;
    private PlayerAttack attack;
    private PlayerDash dash;
   
    void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<PlayerAnimator>();
        attack = GetComponent<PlayerAttack>();
        dash = GetComponent<PlayerDash>();
    }

    void Update()
    {
        Vector2 moveInput = input.GetMovementInput();
        movement.Move(moveInput);
        animator.UpdateAnimation(moveInput);
        if (input.IsLeftClickPressed())
        {
            attack.Attack();
        }
        if (input.IsRightClickPressed()) 
        {
            dash.Dash();
        }
    }
}

