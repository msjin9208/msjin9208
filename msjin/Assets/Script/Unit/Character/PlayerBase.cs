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


        //�÷��̾� �ִϸ����� ����
        _playerAnimation = new PlayerAnimationManager();

        //�޼��� ���
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemUsed, ItemUse);
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
     switch(item.GETITEMTYPE)
		{
            case ItemType.Weapon:
                _attack += item.GETITEMFUNCTIONVALUE;
                Debug.Log(string.Format("���ݷ� : " + _attack.ToString()));
                break;
            case ItemType.Armor:
                _defence += item.GETITEMFUNCTIONVALUE;
                Debug.Log(string.Format("���� : " + _defence.ToString()));
                break;
            case ItemType.Hand:
                _attackSpeed += item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Foot:
                _defence += item.GETITEMFUNCTIONVALUE;
                break;
            case ItemType.Potion:
                _hp += item.GETITEMFUNCTIONVALUE;
                break;
        }
	}

	private void OnDestroy()
	{
        Messenger.RemoveListener<DropItemBase>(Definition.PlayerItemUsed, ItemUse);
    }
}
