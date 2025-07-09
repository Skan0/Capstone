using UnityEngine;
public enum AttackType
{
    LightAttack,    //경공격
    MediumAttack,   //중공격
    HeavyAttack,    //강공격
    SpecialAttack   //특수공격
}
public enum RangeType
{
    Melee,          //근거리
    Ranged          //원거리
}
//위의 형태로 enum을 사용해 무기들을 타입별로 처리한다면
//같은 타입 무기의 확장성에 좋다.(대검에서 불의 대검, 전기의 대검과 같은 파생형)
//하지만 우리는 8종류의 모두 다른 특징을 가지는 무기들로 이루어져 있기 때문에
//타입으로 나누어야 하는가(?)에 대한 의문점이 생겼다.

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float attackRange;                   // 원거리 근거리 뿐만 아니라 무기의 크기 자체의 차이 때문에 사거리가 달라질 수 있다.
    public float moveSpeedMultiplier;
    public AttackType attackType;
    public RangeType rangeType;
    public AnimationClip attackAnimation;
}
