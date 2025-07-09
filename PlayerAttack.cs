using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public void SetWeapon(string weaponName)
    {
        //case문에는 무기 변경 애니메이션을 넣을 생각이다.
        switch (weaponName)
        {
            //단검
            case "ShortSword":
                break;
            //장검
            case "LongSword":
                break;
            //대검
            case "GreatSword":
                break;
            //방패
            case "Shield":
                break;
            //기관단총
            case "SMG":
                break;
            //돌격소총
            case "Assault Rifle":
                break;
            //샷건
            case "ShotGun":
                break;
            //스나이퍼
            case "Sniper":
                break;
            default:
                break;
        }
    }
    public void Attack(string weaponName)
    {
        //손에 들고 있는 무기에 따라 다른 공격이 나가야함
        

    }
}
