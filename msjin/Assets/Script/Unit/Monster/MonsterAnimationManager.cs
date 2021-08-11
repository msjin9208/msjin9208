using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationManager
{
    Animator _monsterAnimator;

    public MonsterAnimationManager(Animator ani)
    {
        _monsterAnimator = ani;
    }

    public void MonsterAnimation(ANIMATIONSTATE animationState, int value)
    {
        _monsterAnimator.SetInteger(animationState.ToString(), value);
    }
    public void MonsterAnimation(ANIMATIONSTATE animationState, bool value)
    {
        _monsterAnimator.SetBool(animationState.ToString(), value);
    }
    public void MonsterAnimation(ANIMATIONSTATE animationState)
    {
        _monsterAnimator.SetTrigger(animationState.ToString());
    }
    public void MonsterAnimation(ANIMATIONSTATE animationState, float value)
    {
        _monsterAnimator.SetFloat(animationState.ToString(), value);
    }
}
