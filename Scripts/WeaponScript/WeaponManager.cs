using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<BasicWeapon> weapons;
    public GameObject WeaponChangeUI;
    public int currentWeaponIndex = 0;
    public float reducedByDash = 2f;

    private float weaponChangeCoolTime = 10f;
    private float lastWeaponChangeTime;

    private void Start()
    {
        lastWeaponChangeTime -= weaponChangeCoolTime;
    }
    void Update()
    {
       
        foreach (var weapon in weapons)
            weapon.UpdateCooldown(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapons[currentWeaponIndex].UseSkill();
        } 
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.time - lastWeaponChangeTime < weaponChangeCoolTime) return;
            Debug.Log("Tab");
            SwitchWeapon();
        }
    }
    public void OnClick(int num)
    {
        // ���� ���� ��Ȱ��ȭ
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // �� ���� �ε��� ����
        currentWeaponIndex = num;

        // �� ���� Ȱ��ȭ
        weapons[currentWeaponIndex].gameObject.SetActive(true);

        // ���� ��ü ��Ÿ�� ����
        lastWeaponChangeTime = Time.time;

        // UI �ݱ�
        WeaponChangeUI.SetActive(false);
    }

    public void ReduceWeaponChangeCoolDown()
    {
        //ȸ�Ǵ뽬�� ���� ���� ��Ÿ�� ����
        weaponChangeCoolTime -= reducedByDash;
    }
    void SwitchWeapon()
    {
        Debug.Log(currentWeaponIndex);
        //lastWeaponChangeTime =Time.time;
        ////currentWeaponIndex�� UI�� ��ư���� ������Ʈ
        //weapons[currentWeaponIndex].gameObject.SetActive(false);
        WeaponChangeUI.SetActive(true);
        //weapons[currentWeaponIndex].gameObject.SetActive(true);
    }
}
