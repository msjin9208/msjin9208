using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill / DebuffSkill", order = int.MaxValue)]
public class DebuffSkill : SkillInfo
{
    private bool _skillUsed;
    public override void InitSkill()
    {
        _skillType = SkillType.DeBuff;
        //스킬 타입에 따라 메세징 관리하기 위함
        SkillTypeSet(_skillType);
        _skillUsed = false;
        base.InitSkill();
    }
    public override void SkillTypeSet(SkillType type)
    {
        base.SkillTypeSet(type);
    }
    public override void Skill(UnitBase target)
    {


        base.Skill(target);
    }

    public override void TurnSkill()
    {
        _debuffTurn -= 1;

        if (_debuffTurn == 0)
        {
            Messenger.RemoveListener(Definition.SkillTurnOver, TurnSkill);
            _debuffTurn = 5;
        }
        base.TurnSkill();
    }

    private void UseSkill(UnitBase target)
    {

    }
}
