using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : DropItemBase
{
    public override void ItemInit(Sprite image, string name, float value, int price, int level)
    {
        _itemImage = ResourceManager.Instance.sprite;
        _itemName = name;
        _itemFunctionValue = value;
        _itemPrice = price;
        _itemLevel = level;

        _stackItem = false;
        _itemType = ItemType.Weapon;
        base.ItemInit(image, name, value, price, level);
    }



}
