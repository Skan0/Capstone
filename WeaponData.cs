using UnityEngine;
public enum AttackType
{
    LightAttack,    //�����
    MediumAttack,   //�߰���
    HeavyAttack,    //������
    SpecialAttack   //Ư������
}
public enum RangeType
{
    Melee,          //�ٰŸ�
    Ranged          //���Ÿ�
}
//���� ���·� enum�� ����� ������� Ÿ�Ժ��� ó���Ѵٸ�
//���� Ÿ�� ������ Ȯ�强�� ����.(��˿��� ���� ���, ������ ��˰� ���� �Ļ���)
//������ �츮�� 8������ ��� �ٸ� Ư¡�� ������ ������ �̷���� �ֱ� ������
//Ÿ������ ������� �ϴ°�(?)�� ���� �ǹ����� �����.

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float attackRange;                   // ���Ÿ� �ٰŸ� �Ӹ� �ƴ϶� ������ ũ�� ��ü�� ���� ������ ��Ÿ��� �޶��� �� �ִ�.
    public float moveSpeedMultiplier;
    public AttackType attackType;
    public RangeType rangeType;
    public AnimationClip attackAnimation;
}
