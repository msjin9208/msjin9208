using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : DropItemBase
{
    public override void ItemInit(Sprite image, string name, float value, int price, int level, EquipType itemtype)
    {
        _itemName = name;
        _itemImage = image;
        _itemFunctionValue = value;
        _itemPrice = price;
        _itemLevel = level;

        _stackItem = false;
        _itemEquipAlready = false;

        _itemType = ItemType.Equip;
        _EquipType = itemtype;

        base.ItemInit(image, name, value, price, level, itemtype);
    }


}
