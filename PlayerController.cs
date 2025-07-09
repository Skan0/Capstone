using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler input;
    private PlayerMovement movement;
    private  PlayerAnimator animator;
    private PlayerAttack attack;
    private PlayerWeaponChanger changer;
    private PlayerDash Dash;

    private string weaponName = "LongSword";
    void Awake()
    {
        input = GetComponent<PlayerInputHandler>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<PlayerAnimator>();
        attack = GetComponent<PlayerAttack>();
        changer = GetComponent<PlayerWeaponChanger>();
        Dash = GetComponent<PlayerDash>();
    }

    void Update()
    {
        Vector2 moveInput = input.GetMovementInput();
        movement.Move(moveInput);
        animator.UpdateAnimation(moveInput);
        if (input.IsLeftClickPressed())
        {
            attack.Attack(weaponName);
        }
        if (input.IsRightClickPressed()) 
        {
            Dash.Dash();
            weaponName = changer.currentWeaponName;
            attack.SetWeapon(weaponName);
        }
    }
}

