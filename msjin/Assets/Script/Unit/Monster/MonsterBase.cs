using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : UnitBase
{
    private int _monsterLevel = 0;
    private MonsterJob _monsterJob;
    private DropItemBase _weapon;

    public override void InitUnit()
    {
        base.InitUnit();
    }

    public void MonsterStatusSetting(float attack, float attackspeed, float defence, float hp, float mp, MonsterJob job)
    {
        _unitStatus._attack = attack;
        _unitStatus._attackSpeed = attackspeed;
        _unitStatus._defence = defence;
        _unitStatus._hp = hp;
        _unitStatus._mp = mp;
        _monsterJob = job;

        SettingMonsterWeapon();
        GetComponent<MonsterEquipment>().EquipmentInit(_weapon);
    }

    private void SettingMonsterWeapon()
    {
        var weapons = ResourceManager.Instance.WEAPONITEM;
        switch (_monsterJob)
        {
            case MonsterJob.Warrior:
                weapons.TryGetValue("BeginerAxe", out _weapon);
                break;
            case MonsterJob.Thief:
                weapons.TryGetValue("Beginerbow", out _weapon);
                break;
            case MonsterJob.Magic:
                weapons.TryGetValue("BeginerWand", out _weapon);
                break;
        }
    }
}
