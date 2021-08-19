using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DeBuffType
{
    None,
    AttackDown,
    AttackSpeedDown,
    DefenceDown
}
public class DeBuffSkill : SkillBase
{
    protected DeBuffType _deBuffType;

    public override void InitSkill()
    {
        base.InitSkill();
    }

    public virtual void SkillUse(UnitBase target)
    {

    }

}
