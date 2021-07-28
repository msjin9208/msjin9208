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

        // �÷��̾� ��� ������ ����
        _playerEquipment = GetComponent<PlayerEquipment>();
        _playerEquipment.EquipmentInit();
        // �÷��̾� ���� ����
        _playerInfo = new PlayerInfo();
        //_playerInfo.playerInfoInit();

        //�÷��̾� �ִϸ����� ����
        _playerAnimation = new PlayerAnimationManager();
    }

    public void UpdatePlayerStateForItem(ITEMFUNCTION itemFunc, float value)
    {
        switch (itemFunc)
        {
            case ITEMFUNCTION.Attack:
                _attack += value;
                Debug.Log(string.Format("���ݷ� : "  +_attack.ToString()));
                break;
            case ITEMFUNCTION.AttackSpeed:
                _attackSpeed += value;
                Debug.Log(string.Format("���� ���ǵ� : " + _attackSpeed.ToString()));
                break;
            case ITEMFUNCTION.Defence:
                _defence += value;
                Debug.Log(string.Format("���� : " + _defence.ToString()));
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
