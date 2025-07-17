using UnityEngine;

public class GreateSword : BasicWeapon
{

    public AudioClip sound;
    public float cooltime = 2f;
    public float elapsedtime;
    public void start()//BasicWeapon의 변수 값 업데이트
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
