using UnityEngine;

public class Snifer : BasicWeapon
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void UseSkill()
    {
        if (!IsSkillReady()) return;

        Debug.Log("Sword Slash!");

        ResetCooldown();
    }
}
