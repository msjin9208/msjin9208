using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipType
{
    NONE,
    Weapon,
    Sheild,
    Helmet,
    Armor,
    Foot,
    Hair,
}
public enum PotionType
{
    NONE,
    HP,
    MP
}

public enum ScrollType
{
    NONE,
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


public class DropItemBase : ScriptableObject
{
    [SerializeField] protected Sprite _itemImage;
    [SerializeField] protected string _itemName;
    [SerializeField] protected float _itemFunctionValue;
    [SerializeField] protected int _itemPrice;
    [SerializeField] protected int _itemLevel;
    [SerializeField] protected bool _stackItem = false;
    [SerializeField] protected bool _itemEquipAlready = false;

    [SerializeField] protected ItemType _itemType;
    [SerializeField] protected EquipType _EquipType;
    [SerializeField] protected ScrollType _scrollType;
    [SerializeField] protected PotionType _potionType;


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
    public virtual void ItemInit()
    {

    }
}
