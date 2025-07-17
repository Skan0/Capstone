using UnityEngine;

public abstract class BasicWeapon : MonoBehaviour
{
    public string weaponName;
    protected AudioClip hitSound;
    protected float cooldownTime;
    protected float cooldownTimer;

    public abstract void UseSkill();

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
