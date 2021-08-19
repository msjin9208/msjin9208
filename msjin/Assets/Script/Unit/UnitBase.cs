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
    protected SkillBase[] _arrayMySkill;
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

    public virtual void Hit()
    {

    }
    public virtual void Attack()
    {

    }
    public virtual void GetBuff(ValueOfBuff _valueType, TypeOfBuff _typeBuff, float value)
    {
    
        
    }
    public virtual void GetDeBuff(ValueOfBuff _valueType, TypeOfBuff _typeBuff, float value)
    {

    }

    public float BuffType(ValueOfBuff _type)
    {
        switch (_type)
        {
            case ValueOfBuff.Attack:
                return _unitStatus._attack;
            case ValueOfBuff.AttackSpeed:
                return _unitStatus._attackSpeed;
            case ValueOfBuff.Defence:
                return _unitStatus._defence;
            case ValueOfBuff.HP:
                return _unitStatus._hp;
            case ValueOfBuff.MP:
                return _unitStatus._mp;
        }

        return default;
    }
}
