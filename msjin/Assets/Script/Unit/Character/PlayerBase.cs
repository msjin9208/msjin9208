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

    public override void InitUnit()
    {
        base.InitUnit();

        _unitStatus._hp = _hp;
        _unitStatus._mp = _mp;
        _unitStatus._attack = _attack;
        _unitStatus._defence = _defence;
        _unitStatus._attackSpeed = _attackSpeed;

        _playerEquipment = GetComponent<PlayerEquipment>();
        _playerEquipment.EquipmentInit();
    }


}
