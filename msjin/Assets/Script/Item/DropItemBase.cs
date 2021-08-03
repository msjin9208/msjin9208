using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemUsed
{
    Weapon,
    Armor,
    Potion
}

public struct ItemInfo
{
    public ItemUsed itemUsed;
    public Texture itemImage;
    public string itemName;
    public float itemFunctionValue;
    public int itemPrice;
}
public class DropItemBase
{
    protected ItemInfo _itemInfo;
    
    public ItemUsed ITEMUSED
    {
        get { return _itemInfo.itemUsed; }
    }
    public Texture ITEMIMAGE
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

    public virtual void ItemUse()
    {
        Debug.Log("¿Â¬¯!!!!!!!");
    }
    public virtual void ItemDestroy()
    {
        Debug.Log("ªË¡¶!!!!!!!");
    }
}
