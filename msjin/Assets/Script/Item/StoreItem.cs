using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : ItemBase
{
    public override void ItemInit(Sprite itemImage, string itemName, int itemPrice, ITEMFUNCTION itemfunc)
    {
        //_itemImage = itemImage;
        _itemName = itemName;
        _itemPrice = itemPrice;
        _itemFuncion = itemfunc;
        _itemFunctionValue = 2f;

        base.ItemInit(_itemImage, _itemName, _itemPrice, itemfunc);
    }
    protected override void ItemPurchase()
    {
        var player = GameManager.Instance.PLAYER;
        var playerGold = player.GetComponent<PlayerBase>().PlayerInfo._info._playerGold;
        if (_itemPrice > playerGold)
        {
            Debug.Log(playerGold);
            UIAnimation.Instance.FailUI("���� �ݾ� �������� ���� �Ұ�!");
        }
        else
        {
            UIAnimation.Instance.FailUI("���� ����!!!");
            player.GetComponent<PlayerBase>().PlayerInfo.ItemPurchase(this._itemPrice, this._itemFuncion, this._itemFunctionValue);
        }
    }

    public override void ItemSetObject(Button obj)
    {
        base.ItemSetObject(obj);
    }
}
