using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : UnitBase
{
    [SerializeField] float _hp;
    [SerializeField] float _mp;
    [SerializeField] float _attack;
    [SerializeField] float _defence;
    [SerializeField] float _attackSpeed;

    private PlayerEquipment _playerEquipment;
    private PlayerInfo _playerInfo;
    private PlayerAnimationManager _playerAnimation;

    public PlayerInfo PlayerInfo
    {
        get { return _playerInfo; }
        set { _playerInfo = value; }
    }
    public PlayerAnimationManager PlayerAnimationManager
    {
        get { return _playerAnimation; }
    }

    public override void InitUnit()
    {
        base.InitUnit();

        _unitStatus._hp = _hp;
        _unitStatus._mp = _mp;
        _unitStatus._attack = _attack;
        _unitStatus._defence = _defence;
        _unitStatus._attackSpeed = _attackSpeed;

        // 플레이어 장비 데이터 생성
        _playerEquipment = GetComponent<PlayerEquipment>();
        _playerEquipment.EquipmentInit();
        // 플레이어 정보 생성
        _playerInfo = new PlayerInfo();
        //_playerInfo.playerInfoInit();

        //플레이어 애니메이터 생성
        _playerAnimation = new PlayerAnimationManager();
    }

    public void UpdatePlayerStateForItem(ITEMFUNCTION itemFunc, float value)
    {
        switch (itemFunc)
        {
            case ITEMFUNCTION.Attack:
                _attack += value;
                Debug.Log(string.Format("공격력 : "  +_attack.ToString()));
                break;
            case ITEMFUNCTION.AttackSpeed:
                _attackSpeed += value;
                Debug.Log(string.Format("공격 스피드 : " + _attackSpeed.ToString()));
                break;
            case ITEMFUNCTION.Defence:
                _defence += value;
                Debug.Log(string.Format("방어력 : " + _defence.ToString()));
                break;
            case ITEMFUNCTION.Hp:
                _hp  += value;
                Debug.Log(string.Format("HP : " + _hp.ToString()));
                break;
            case ITEMFUNCTION.Mp:
                _mp += value;
                Debug.Log(string.Format("MP : " + _mp.ToString()));
                break;
        }
    }
}
