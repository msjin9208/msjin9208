using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : UnitBase
{
    private int _monsterLevel = 0;
    private MonsterJob _monsterJob;
    private DropItemBase _weapon;
    
    

    public bool MONSTERDEATH
    {
        get { return _death; }
    }
    public override void InitUnit()
    {
        base.InitUnit();
    }

    public void MonsterStatusSetting(int level, MonsterJob job)
    {
        _monsterLevel = level;
        _monsterJob = job;

        SettingMonsterWeapon();
        MonsterStatus();
        GetComponent<MonsterEquipment>().EquipmentInit(_weapon);
    }

    private void SettingMonsterWeapon()
    {
        if (_weapon != null)
            _weapon = null;

        var weapons = ResourceManager.Instance.WEAPONITEM;
        switch (_monsterJob)
        {
            case MonsterJob.Warrior:
                weapons.TryGetValue("BeginerAxe", out _weapon);
                break;
            case MonsterJob.Thief:
                weapons.TryGetValue("BeginerSword", out _weapon);
                break;
            case MonsterJob.Magic:
                weapons.TryGetValue("BeginerWand", out _weapon);
                break;
        }
    }
    private void MonsterStatus()
    {
        float status = _monsterLevel += 5;

        _unitStatus._attack = status + 2;
        _unitStatus._attackSpeed = status + 1;
        _unitStatus._defence = status + 1;
        _unitStatus._hp = status + 5;
        _unitStatus._mp = status;
    }
}
