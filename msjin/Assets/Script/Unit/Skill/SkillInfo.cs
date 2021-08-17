using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Attack,
    Defence,
    Buff,
    DeBuff
}
public enum SkillValueType
{
    HP,
    MP,
    Attack,
    AttackSpeed,
    Defence
}


public class SkillInfo : ScriptableObject
{
    protected SkillType _skillType;
    protected bool _attacking = false;

    [SerializeField]protected string _skillInfo;
    [SerializeField]protected float _skillFunctionValue;
    [SerializeField] protected int _debuffTurn;

    [SerializeField] protected SkillValueType _skillValueType;
    [SerializeField] Sprite _skillImage;

    public string SKILLINFO
    {
        get { return _skillInfo; }
    }


    public virtual void InitSkill()
    {
        
    }
    public virtual void SkillTypeSet(SkillType type)
    {
        switch (type)
        {
            case SkillType.Attack:
                break;
            case SkillType.Defence:
                break;
            case SkillType.Buff:
                Messenger.AddListener(Definition.SkillTurnOver, TurnSkill);
                break;
            case SkillType.DeBuff:
                Messenger.AddListener(Definition.SkillTurnOver, TurnSkill);
                break;
        }
    }

    public virtual void Skill(UnitBase target)
    {

        
    }

    //���� �ִ� ��ų�� ��� �Ͽ��� ���
    public virtual void TurnSkill()
    {
        
    }

    
}



