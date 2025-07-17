using UnityEngine;

public class GreateSword : BasicWeapon
{

    public AudioClip sound;
    public float cooltime = 2f;
    public float elapsedtime;
    public void start()//BasicWeapon�� ���� �� ������Ʈ
    {
        hitSound = sound;
        cooldownTime = cooltime;
    }

    public override void UseSkill()
    {
        if (!IsSkillReady()) return;

        Debug.Log("Sword Slash!");
        
        ResetCooldown();
    }
}
