using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBattle : MonoBehaviour
{
    protected SkillInfo _unitSkill;

    // Start is called before the first frame update
    void Start()
    {
        _unitSkill = new SkillInfo();
        _unitSkill.InitSkill();
    }

    public virtual void Attack(UnitBase target)
    {

    }
    public virtual void SkillAttack(UnitBase target)
    {

    }
    
}
