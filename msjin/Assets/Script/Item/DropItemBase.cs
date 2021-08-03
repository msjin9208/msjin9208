using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemUsed
{
    Weapon,
    Armor,
    Hand,
    Foot,
    Potion
}

public struct ItemInfo
{
    public ItemUsed itemUsed;
    public Sprite itemImage;
    public string itemName;
    public float itemFunctionValue;
    public int itemPrice;
    public bool Used;
}
public class DropItemBase
{
    protected ItemInfo _itemInfo;
    public bool USED
	{
		get { return _itemInfo.Used; }
	}
    public ItemUsed ITEMUSED
    {
        get { return _itemInfo.itemUsed; }
    }
    public Sprite ITEMIMAGE
    {
        get { return _itemInfo.itemImage; }
    }
    public string ITEMNAME
    {
        get { return _itemInfo.itemName; }
    }
    public float ITEMFUNCTIONVALUE
    {
        get { return _itemInfo.itemFunctionValue; }
    }
    public int ITEMPRICE
    {
        get { return _itemInfo.itemPrice; }
    }

    public virtual void  ItemInit()
    {
        _itemInfo.itemImage = ResourceManager.Instance.sprite;
        _itemInfo.itemName = "AXE!";
        _itemInfo.itemPrice = 100;
        _itemInfo.itemFunctionValue = 20;
    }

    public virtual void ItemUse(ItemUsed itemUsed, DropItemBase item)
    {
        Debug.Log("¿Â¬¯!!!!!!!");

        if (USED == false)
        {
            Messenger.Broadcast(Definition.PlayerItemUsed, itemUsed, item);
            _itemInfo.Used = true;
        }
        else
		{
            Messenger.Broadcast(Definition.PlayerItemUnEquip, itemUsed, item);
            _itemInfo.Used = false;
		}
    }

    public virtual void ItemDestroy()
    {
        Debug.Log("ªË¡¶!!!!!!!");
    }
}
