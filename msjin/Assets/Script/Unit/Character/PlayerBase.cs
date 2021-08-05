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

    public override void InitUnit()
    {
        base.InitUnit();

        _unitStatus._hp = _hp;
        _unitStatus._mp = _mp;
        _unitStatus._attack = _attack;
        _unitStatus._defence = _defence;
        _unitStatus._attackSpeed = _attackSpeed;

        //���� ������ ����Ʈ
        _currentEquipItemList = new List<DropItemBase>();

        // �÷��̾� ���� ����
        _playerInfo = new PlayerInfo();

        //�÷��̾� �ִϸ����� ����
        _playerAnimation = new PlayerAnimationManager();

        //�޼��� ���
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemUsed, ItemUse);
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemUnEquip, UnEquip);
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

    private void ItemUse(DropItemBase item)
    {
        if (item.GETITEMEQUIPALREADY == true)
            return;

        var alreadyEquipItem = FindAlreadyEquipmentITem(item);

        if(alreadyEquipItem != null)
            UnEquip(alreadyEquipItem);

         switch(item.GETITEMTYPE)
		  {
                case ItemType.Weapon:
                    _attack += item.GETITEMFUNCTIONVALUE;
                    Debug.Log(string.Format("���ݷ� : " + _attack.ToString()));
                    break;
                case ItemType.Sheild:
                    _attackSpeed += item.GETITEMFUNCTIONVALUE;
                    break;
                case ItemType.Armor:
                    _defence += item.GETITEMFUNCTIONVALUE;
                    Debug.Log(string.Format("���� : " + _defence.ToString()));
                    break;
            case ItemType.Helmet:
                _attackSpeed += item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Hair:
                _attackSpeed += item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Foot:
                    _defence += item.GETITEMFUNCTIONVALUE;
                    break;
                case ItemType.Potion:
                    _hp += item.GETITEMFUNCTIONVALUE;
                    break;
        }

        item.GETITEMEQUIPALREADY = true;
        _currentEquipItemList.Add(item);
	}

    private void UnEquip(DropItemBase item)
    {
        if (item.GETITEMEQUIPALREADY == false)
            return;

        switch (item.GETITEMTYPE)
        {
            case ItemType.Weapon:
                _attack -= item.GETITEMFUNCTIONVALUE;
                Debug.Log(string.Format("���ݷ� : " + _attack.ToString()));
                break;
            case ItemType.Armor:
                _defence -= item.GETITEMFUNCTIONVALUE;
                Debug.Log(string.Format("���� : " + _defence.ToString()));
                break;
            case ItemType.Sheild:
                _attackSpeed -= item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Helmet:
                _attackSpeed -= item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Hair:
                _attackSpeed -= item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Foot:
                _defence -= item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Potion:
                _hp -= item.GETITEMFUNCTIONVALUE;
                break;
        }

        item.GETITEMEQUIPALREADY = false;
        _currentEquipItemList.Remove(item);
    }


    private DropItemBase FindAlreadyEquipmentITem(DropItemBase item)
    {
        if (_currentEquipItemList.Count <= 0 || _currentEquipItemList == null)
            return null;

        foreach(var foundItem in _currentEquipItemList)
        {
            if (foundItem.GETITEMTYPE == item.GETITEMTYPE)
                return foundItem;
        }

        return null;
    }

	private void OnDestroy()
	{
        Messenger.RemoveListener<DropItemBase>(Definition.PlayerItemUsed, ItemUse);
        Messenger.RemoveListener<DropItemBase>(Definition.PlayerItemUnEquip, UnEquip);
    }
}
