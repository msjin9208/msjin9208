using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None,
    Attack,
    Defence,
    Buff,
    DeBuff
}


public class SkillBase
{
    protected SkillType _skillType;

    public virtual void InitSkill()
    {

    }
}
