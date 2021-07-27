using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ANIMATIONSTATE
{
    Idle,
    bRun
}

public class PlayerAnimationManager
{
    Animator _playerAnimator;

    public PlayerAnimationManager()
    {
        _playerAnimator = GameManager.Instance.PLAYER.GetComponentInChildren<Animator>();
    }

    public void PlayerAnimation(ANIMATIONSTATE animationState, int value)
    {
        _playerAnimator.SetInteger(animationState.ToString(), value);
    }
    public void PlayerAnimation(ANIMATIONSTATE animationState, bool value)
    {
        _playerAnimator.SetBool(animationState.ToString(), value);
    }
    public void PlayerAnimation(ANIMATIONSTATE animationState)
    {
        _playerAnimator.SetTrigger(animationState.ToString());
    }
    public void PlayerAnimation(ANIMATIONSTATE animationState, float value)
    {
        _playerAnimator.SetFloat (animationState.ToString(), value);
    }
}
