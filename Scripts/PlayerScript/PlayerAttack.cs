using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public string curweapon;

    //�̰� weapon animator�� ���� ���� �����ϴ����� ���ڴ�.
    public void SetWeapon(string weaponName)
    {
        //case������ ���� ���� �ִϸ��̼��� ���� �����̴�.
        switch (weaponName)
        {
            //�ܰ�
            case "ShortSword":
                break;
            //���
            case "LongSword":
                break;
            //���
            case "GreatSword":
                break;
            //����
            case "Shield":
                break;
            //�������
            case "SMG":
                break;
            //���ݼ���
            case "Assault Rifle":
                break;
            //����
            case "ShotGun":
                break;
            //��������
            case "Sniper":
                break;
            default:
                break;
        }
    }
    public void Attack( )
    {
        //�տ� ��� �ִ� ���⿡ ���� �ٸ� ������ ��������
        

    }
}
