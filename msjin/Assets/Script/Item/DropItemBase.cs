using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipType
{
    Weapon,
    Sheild,
    Helmet,
    Armor,
    Foot,
    Hair,
}
public enum PotionType
{
    HP,
    MP
}

public enum ScrollType
{
    Weapon,
    Sheild,
    Helmet,
    Armor,
    Foot,
}
public enum ItemType
{
    Equip,
    Potion,
    Scroll
}

public class DropItemBase
{
    protected Sprite _itemImage;
    protected string _itemName;
    protected float _itemFunctionValue;
    protected int _itemPrice;
    protected int _itemLevel;
    protected bool _stackItem = false;
    protected bool _itemEquipAlready = false;

    protected ItemType _itemType;
    protected EquipType _EquipType;
    protected ScrollType _scrollType;
    protected PotionType _potionType;


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
    public EquipType GETEQUIPTYPE
    {
        get { return _EquipType; }
    }

    public bool GETITEMEQUIPALREADY
    {
        get { return _itemEquipAlready; }
        set { _itemEquipAlready = value; }
    }
    public virtual void ItemInit(Sprite image, string name, float value, int price, int level, EquipType itemtype)
    {

    }
}
