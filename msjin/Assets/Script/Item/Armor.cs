using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : DropItemBase
{
    public override void ItemInit(Sprite image, string name, float value, int price, int level, ItemType itemtype)
    {
        _itemImage = image;
        _itemName = name;
        _itemFunctionValue = value;
        _itemPrice = price;
        _itemLevel = level;

        _stackItem = false;
        _itemType = itemtype;
        base.ItemInit(image, name, value, price, level, itemtype);
    }


}
