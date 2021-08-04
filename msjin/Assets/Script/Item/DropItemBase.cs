using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Weapon,
    Armor,
    Hand,
    Foot,
    Potion
}

public class DropItemBase
{
    protected Sprite _itemImage;
    protected string _itemName;
    protected float _itemFunctionValue;
    protected int _itemPrice;
    protected int _itemLevel;
    protected int _itemAmount;
    protected bool _stackItem = false;

    protected ItemType _itemType;

    public Sprite GETITEMIMAGE
    {
        get { return _itemImage; }
    }
    public string GETITEMNAME
    {
        get { return _itemName; }
    }
    public float GETITEMFUNCTIONVALUE
    {
        get { return _itemFunctionValue; }
    }
    public int GETITEMPRICE
    {
        get { return _itemPrice; }
    }
    public int GETITEMLEVEL
    {
        get { return _itemLevel; }
    }
    public bool GETSTACK
    {
        get { return _stackItem; }
    }
    public ItemType GETITEMTYPE
    {
        get { return _itemType; }
    }
    public int GETITEMAMOUNT
    {
        get { return _itemAmount; }
        set { _itemAmount = value; }
    }

    public virtual void ItemInit(Sprite image, string name, float value, int price, int level, ItemType itemtype)
    {

    }

}
