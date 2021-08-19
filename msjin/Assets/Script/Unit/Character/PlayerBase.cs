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

    private PlayerInfo _playerInfo;
    private PlayerAnimationManager _playerAnimation;
    private List<DropItemBase> _currentEquipItemList;
    

    public PlayerInfo PlayerInfo
    {
        get { return _playerInfo; }
        set { _playerInfo = value; }
    }
    public PlayerAnimationManager PlayerAnimationManager
    {
        get { return _playerAnimation; }
    }
    public bool MONSTERDEATH
    {
        get { return _death; }
    }

    public override void InitUnit()
    {
        base.InitUnit();

        _unitStatus._hp = _hp;
        _unitStatus._mp = _mp;
        _unitStatus._attack = _attack;
        _unitStatus._defence = _defence;
        _unitStatus._attackSpeed = _attackSpeed;

        //장착 아이템 리스트
        _currentEquipItemList = new List<DropItemBase>();

        // 플레이어 정보 생성
        _playerInfo = new PlayerInfo();

        //플레이어 애니메이터 생성
        _playerAnimation = new PlayerAnimationManager();

        //플레이어 전투 스킬 세팅
        _arrayMySkill = new SkillBase[10];
        _arrayMySkill = null;

        //메세지 등록
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemEquip, ItemUse);
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemUnEquip, UnEquip);
    }

    #region 상점 아이템
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
    #endregion

    #region 아이템 착용 및 사용
    private void ItemUse(DropItemBase item)
    {
        if (item.GETITEMEQUIPALREADY == true)
            return;

        var alreadyEquipItem = FindAlreadyEquipmentITem(item);

        if(alreadyEquipItem != null)
        {
            UnEquip(alreadyEquipItem);
            
        }

        AddItemStatus(item.GETEQUIPTYPE, item.GETITEMFUNCTIONVALUE);


        item.GETITEMEQUIPALREADY = true;
        _currentEquipItemList.Add(item);
	}
    private void AddItemStatus(EquipType type, float value)
    {
        switch (type)
        {
            case EquipType.Weapon:
                _attack += value;
                Debug.Log(string.Format("공격력 : " + _attack.ToString()));
                break;
            case EquipType.Sheild:
                _attackSpeed += value;
                break;
            case EquipType.Armor:
                _defence += value;
                Debug.Log(string.Format("방어력 : " + _defence.ToString()));
                break;
            case EquipType.Helmet:
                _attackSpeed += value;
                break;
            case EquipType.Hair:
                _attackSpeed += value;
                break;
            case EquipType.Foot:
                _defence += value;
                break;
        }
    }
    #endregion

    #region 아이템 해제
    private void UnEquip(DropItemBase item)
    {
        if (item.GETITEMEQUIPALREADY == false)
            return;

        MinusItemStatus(item.GETEQUIPTYPE, item.GETITEMFUNCTIONVALUE);


        item.GETITEMEQUIPALREADY = false;
        _currentEquipItemList.Remove(item);
    }
    private void MinusItemStatus(EquipType type, float value)
    {
        switch (type)
        {
            case EquipType.Weapon:
                _attack -= value;
                Debug.Log(string.Format("공격력 : " + _attack.ToString()));
                break;
            case EquipType.Sheild:
                _attackSpeed -= value;
                break;
            case EquipType.Armor:
                _defence -= value;
                Debug.Log(string.Format("방어력 : " + _defence.ToString()));
                break;
            case EquipType.Helmet:
                _attackSpeed -= value;
                break;
            case EquipType.Hair:
                _attackSpeed -= value;
                break;
            case EquipType.Foot:
                _defence -= value;
                break;
        }
    }

    private DropItemBase FindAlreadyEquipmentITem(DropItemBase item)
    {
        if (_currentEquipItemList.Count <= 0 || _currentEquipItemList == null)
            return null;

        foreach(var foundItem in _currentEquipItemList)
        {
            if (foundItem.GETEQUIPTYPE == item.GETEQUIPTYPE)
                return foundItem;
        }
                return null;
    }
    #endregion

    #region 전투
    public override void Attack()
    {
        base.Attack();
    }

    public override void Hit()
    {
        base.Hit();
    }
    public override void GetBuff(ValueOfBuff _valueType, TypeOfBuff _typeBuff, float value)
    {
        base.GetBuff(_valueType, _typeBuff, value);
    }
    public override void GetDeBuff(ValueOfBuff _valueType, TypeOfBuff _typeBuff, float value)
    {
        base.GetDeBuff(_valueType, _typeBuff, value);
    }

    #endregion


    private void OnDestroy()
	{
        Messenger.RemoveListener<DropItemBase>(Definition.PlayerItemEquip, ItemUse);
        Messenger.RemoveListener<DropItemBase>(Definition.PlayerItemUnEquip, UnEquip);
    }
}
