using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UnitBase : MonoBehaviour
{
    public struct UnitStatus
    {
       public float _hp { get; set; }
        public float _mp { get; set; }
        public float _attack { get; set; }
        public float _defence { get; set; }
        public float _attackSpeed { get; set; }
    }

    protected UnitStatus _unitStatus;
    protected bool _death = false;
    protected float _maxHP;

    public UnitStatus UNITSTATUS
    {
        get { return _unitStatus; }
    }
    

    public virtual void InitUnit()
    {
        _unitStatus = new UnitStatus();
        _maxHP = _unitStatus._hp;
    }

    public virtual void HP(float hp, bool attack)
    {
        if (attack == true)
        {
            _unitStatus._hp -= hp;
            if (_unitStatus._hp <= 0)
            {
                _unitStatus._hp = 0;
            }
        }
        else
        {
            _unitStatus._hp += hp;
            if(_unitStatus._hp > _maxHP)
            {
                _unitStatus._hp = _maxHP;
            }
        }
    }
    
    public virtual void HitDebuffSkill(SkillValueType type, float value)
    {
        switch (type)
        {
            case SkillValueType.Attack:
                
                break;
            case SkillValueType.AttackSpeed:
                break;
            case SkillValueType.Defence:
                break;
            case SkillValueType.HP:
                break;
            case SkillValueType.MP:
                break;
        }
}
}
