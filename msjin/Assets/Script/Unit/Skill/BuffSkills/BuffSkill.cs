using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuffType
{
    None,
    Heal,
    AttackUp,
    AttackSpeedUp,
    DefenceUp
}
public enum TypeOfBuff
{
    Tick,
    Once
}

public enum ValueOfBuff
{
    Attack,
    AttackSpeed,
    Defence,
    HP,
    MP
}

public class BuffSkill : SkillBase
{

    protected BuffType _buffType;
    protected TypeOfBuff _typeOfBuff;
    protected ValueOfBuff _valueOfBuff;
    protected float _value;
    protected int _turn;

    public override void InitSkill()
    {
        base.InitSkill();
        _skillType = SkillType.Buff;
    }

    public virtual void SkillUse(UnitBase target)
    {
        
    }
}
