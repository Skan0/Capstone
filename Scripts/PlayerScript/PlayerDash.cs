using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public GameObject WeaponChangeUI;
    private PlayerWeaponChanger changer;
    private PlayerMovement movement;
    private float dashCooldown = 2.0f;
    private float lastDashTime;
    private bool IsinAvoid = false;

    private float dashPower = 50f;       //대쉬 했을 때 얼마나 진행방향으로 이동할지

    private void Start()
    {
        lastDashTime = -dashCooldown; // 시작하자마자 한 번 사용할 수 있도록
        movement = GetComponent<PlayerMovement>();
        changer = GetComponent<PlayerWeaponChanger>();
    }
    public void Dash()
    {
        Debug.Log(IsinAvoid);
        if (IsinAvoid) 
            AvoidDash();
        else 
            BasicDash();
    }

  
    private void BasicDash()//기본 이동만 하는 대쉬
    {
        if (Time.time - lastDashTime < dashCooldown) return;
        Debug.Log("BasicDash");   
        lastDashTime = Time.time;

        Vector3 dashDirection = movement.GetLastMoveDirection(); // movement에서 가져옴
        movement.ForceMove(dashDirection, dashPower);
    }

    private void AvoidDash()//공격 회피 
    {
        if (Time.time - lastDashTime < dashCooldown) return;

        lastDashTime = Time.time;
        //그냥 대쉬하면서 변경할거면 위에거 그대로 가져와서 사용하고 아니면
        //추가적으로 모션이나 위치 변경을 구현하도록
        //무기변경하는 기능
        WeaponChangeUI.SetActive(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            IsinAvoid = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            IsinAvoid = false;
        }
    }
}
