using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : UnitBase
{
    private int _monsterLevel = 0;

    public override void InitUnit()
    {
        base.InitUnit();

        MonsterStatusSetting(); 
    }

    private void MonsterStatusSetting()
    {
        _unitStatus._attack = 0;
        _unitStatus._attackSpeed = 0;
        _unitStatus._defence = 0;
        _unitStatus._hp = 0;
        _unitStatus._mp = 0;

    }


}
