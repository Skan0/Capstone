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
        // 기존 무기 비활성화
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // 새 무기 인덱스 설정
        currentWeaponIndex = num;

        // 새 무기 활성화
        weapons[currentWeaponIndex].gameObject.SetActive(true);

        // 무기 교체 쿨타임 갱신
        lastWeaponChangeTime = Time.time;

        // UI 닫기
        WeaponChangeUI.SetActive(false);
    }

    public void ReduceWeaponChangeCoolDown()
    {
        //회피대쉬로 무기 변경 쿨타임 감소
        weaponChangeCoolTime -= reducedByDash;
    }
    void SwitchWeapon()
    {
        Debug.Log(currentWeaponIndex);
        //lastWeaponChangeTime =Time.time;
        ////currentWeaponIndex는 UI의 버튼으로 업데이트
        //weapons[currentWeaponIndex].gameObject.SetActive(false);
        WeaponChangeUI.SetActive(true);
        //weapons[currentWeaponIndex].gameObject.SetActive(true);
    }
}
