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
    private float dashPower = 50f;       //�뽬 ���� �� �󸶳� ����������� �̵�����

    private void Start()
    {
        lastDashTime = -dashCoolTime; // �������ڸ��� �� �� ����� �� �ֵ���
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

   
    private void BasicDash()//�⺻ �̵��� �ϴ� �뽬
    {
        if (Time.time - lastDashTime < dashCoolTime) return;
        Debug.Log("BasicDash");   
        lastDashTime = Time.time;

        Vector3 dashDirection = movement.GetLastMoveDirection(); // movement���� ������
        movement.ForceMove(dashDirection, dashPower);
        anim.BasicDashAnim();
        for (int i = 0; i < 3; i++) // �ܻ� 3 �� ����
        {
            StartCoroutine(CreateAfterImageDelay(0.05f * i));
        }
    }

    private void AvoidDash()//���� ȸ�� 
    {
        if (Time.time - lastDashTime < dashCoolTime) return;

        lastDashTime = Time.time;
        anim.AvoidDashAnim();
        //�� ȸ�� �뽬�� ���� ���� ���� ��Ÿ���� ���� �� �ִ�.
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
