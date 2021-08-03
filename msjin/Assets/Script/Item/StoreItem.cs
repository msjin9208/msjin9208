using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : ItemBase
{
    public override void ItemInit(Sprite itemImage, string itemName, int itemPrice, ITEMFUNCTION itemfunc)
    {
        _itemImage = itemImage;
        _itemName = itemName;
        _itemPrice = itemPrice;
        _itemFuncion = itemfunc;
        _itemFunctionValue = 2f;

        base.ItemInit(_itemImage, _itemName, _itemPrice, itemfunc);
    }
    protected override void ItemPurchase()
    {
        var animationing = UIAnimation.Instance.FAILANIMAITION;
        if (animationing == true)
            return;

        var player = GameManager.Instance.PLAYER;
        var playerGold = player.GetComponent<PlayerBase>().PlayerInfo._info._playerGold;
        if (_itemPrice > playerGold)
        {
            Debug.Log(playerGold);
            UIAnimation.Instance.FailUI("소지 금액 부족으로 구매 불가!");
        }
        else
        {
            UIAnimation.Instance.FailUI("구매 성공!!!");
            //player.GetComponent<PlayerBase>().PlayerInfo.ItemPurchase(this._itemPrice, this._itemFuncion, this._itemFunctionValue);
            Messenger.Broadcast(Definition.PlayerPurchase, this._itemPrice, this._itemFuncion, this._itemFunctionValue);
            Messenger.Broadcast(Definition.RefreshPlayerInfo);

            this._itemPrice += 10;
            RefreshItem();
        }
    }

    public override void ItemSetObject(Button obj)
    {
        base.ItemSetObject(obj);
    }
}
