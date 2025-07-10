using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public GameObject WeaponChangeUI;
    //private PlayerWeaponChanger changer;
    private PlayerAnimator anim;
    private PlayerMovement movement;
    private float dashCooldown = 2.0f;
    private float lastDashTime;
    private bool IsinAvoid = false;

    private float dashPower = 50f;       //�뽬 ���� �� �󸶳� ����������� �̵�����

    private void Start()
    {
        lastDashTime = -dashCooldown; // �������ڸ��� �� �� ����� �� �ֵ���
        movement = GetComponent<PlayerMovement>();
        //changer = GetComponent<PlayerWeaponChanger>();
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
        if (Time.time - lastDashTime < dashCooldown) return;
        Debug.Log("BasicDash");   
        lastDashTime = Time.time;

        Vector3 dashDirection = movement.GetLastMoveDirection(); // movement���� ������
        movement.ForceMove(dashDirection, dashPower);
        anim.BasicDashAnim();
        for (int i = 0; i < 3; i++) // �ܻ� ���� �� ����
        {
            StartCoroutine(CreateAfterImageDelay(0.05f * i));
        }
    }

    private void AvoidDash()//���� ȸ�� 
    {
        if (Time.time - lastDashTime < dashCooldown) return;

        lastDashTime = Time.time;
        anim.AvoidDashAnim();
        //�׳� �뽬�ϸ鼭 �����ҰŸ� ������ �״�� �����ͼ� ����ϰ� �ƴϸ�
        //�߰������� ����̳� ��ġ ������ �����ϵ���
        //���⺯���ϴ� ���
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
