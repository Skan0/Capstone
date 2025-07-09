using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private float dashCooldown = 2.0f;
    private float lastDashTime;
    private bool IsinAvoid = false;
    private void Start()
    {
        lastDashTime = -dashCooldown; // �������ڸ��� �� �� ����� �� �ֵ���
    }
    public void Dash()
    {
        if (IsinAvoid) 
            AvoidDash();
        else 
            BasicDash();
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
    private void BasicDash()
    {
        if (Time.time - lastDashTime < dashCooldown) return;

        lastDashTime = Time.time;
    }

    private void AvoidDash()
    {
        if (Time.time - lastDashTime < dashCooldown) return;

        lastDashTime = Time.time;
    }
}
