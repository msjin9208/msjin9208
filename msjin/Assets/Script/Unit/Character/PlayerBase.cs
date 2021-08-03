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
                _unitStatus._attack += value;
                Messenger.Broadcast(Definition.RefreshPlayerInfoInStore, itemFunc, _unitStatus._attack);
                break;
            case ITEMFUNCTION.AttackSpeed:
                _unitStatus._attackSpeed += value;
                Messenger.Broadcast(Definition.RefreshPlayerInfoInStore, itemFunc, _unitStatus._attackSpeed);
                break;
            case ITEMFUNCTION.Defence:
                _unitStatus._defence += value;
                Messenger.Broadcast(Definition.RefreshPlayerInfoInStore, itemFunc, _unitStatus._defence);
                break;
            case ITEMFUNCTION.Hp:
                _unitStatus._hp += value;
                Messenger.Broadcast(Definition.RefreshPlayerInfoInStore, itemFunc, _unitStatus._hp);
                break;
            case ITEMFUNCTION.Mp:
                _unitStatus._mp+= value;
                Messenger.Broadcast(Definition.RefreshPlayerInfoInStore, itemFunc, _unitStatus._mp);
                break;
        }

        
    }
}
