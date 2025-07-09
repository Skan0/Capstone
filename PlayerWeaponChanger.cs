using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponChanger : MonoBehaviour
{
    public string currentWeaponName = "LongSword";
    public GameObject WeaponChangeUI;


    public void ChangeWeapon(string weaponName)
    {
        currentWeaponName = weaponName;
        // ex) PlayerWeaponManager.SetWeapon(weaponName);
    }
}
