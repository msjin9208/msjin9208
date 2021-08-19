using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : BuffSkill
{

    public override void InitSkill()
    {
        base.InitSkill();
        _typeOfBuff = TypeOfBuff.Once;
        _valueOfBuff = ValueOfBuff.HP;
        _turn = 1;
        _value = 10;
    }

    public override void SkillUse(UnitBase target)
    {
        base.SkillUse(target);
        target.GetBuff(_valueOfBuff, _typeOfBuff, _value);
    }

}
