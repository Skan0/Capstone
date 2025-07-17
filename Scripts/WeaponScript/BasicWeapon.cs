using UnityEngine;

public abstract class BasicWeapon : MonoBehaviour
{
    public string weaponName;
    protected AudioClip hitSound;
    protected float cooldownTime;
    protected float cooldownTimer;
    public void Awake()
    {
        weaponName = transform.name;
    }
    public abstract void UseSkill();
    //이 함수는 상속만 받고 개별적으로 구현할 생각이다.
    public virtual void UpdateCooldown(float deltaTime)
    {
        if (cooldownTimer > 0)
            cooldownTimer -= deltaTime;
    }

    public virtual bool IsSkillReady()
    {
        return cooldownTimer <= 0;
    }

    public virtual void ResetCooldown()
    {
        cooldownTimer = cooldownTime;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 공통 피격 효과
            PlayHitSound();
        }
    }

    protected void PlayHitSound()
    {
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
    }
}
