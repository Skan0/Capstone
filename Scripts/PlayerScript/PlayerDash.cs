using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public GameObject WeaponChangeUI;
    private PlayerAnimator anim;
    private PlayerMovement movement;
    private float dashCoolTime = 2.0f;
    private float lastDashTime;
    private bool IsinAvoid = false;
    private float dashPower = 50f;       //대쉬 했을 때 얼마나 진행방향으로 이동할지

    private void Start()
    {
        lastDashTime = -dashCoolTime; // 시작하자마자 한 번 사용할 수 있도록
        movement = GetComponent<PlayerMovement>();
        anim = GetComponent<PlayerAnimator>();  
    }
    public void Dash()
    {
        Debug.Log(IsinAvoid);
        if (IsinAvoid) 
            AvoidDash();
        else 
            BasicDash();
    }
    

    IEnumerator CreateAfterImageDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        movement.CreateAfterImage();
    }

   
    private void BasicDash()//기본 이동만 하는 대쉬
    {
        if (Time.time - lastDashTime < dashCoolTime) return;
        Debug.Log("BasicDash");   
        lastDashTime = Time.time;

        Vector3 dashDirection = movement.GetLastMoveDirection(); // movement에서 가져옴
        movement.ForceMove(dashDirection, dashPower);
        anim.BasicDashAnim();
        for (int i = 0; i < 3; i++) // 잔상 3 개 생성
        {
            StartCoroutine(CreateAfterImageDelay(0.05f * i));
        }
    }

    private void AvoidDash()//공격 회피 
    {
        if (Time.time - lastDashTime < dashCoolTime) return;

        lastDashTime = Time.time;
        anim.AvoidDashAnim();
        //이 회피 대쉬를 통해 무기 변경 쿨타임을 줄일 수 있다.
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
