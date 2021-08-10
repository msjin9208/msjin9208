using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;


public enum WeaponType
{
    Sword,
    Axe,
    Bow,
    Wand
}
[CreateAssetMenu(fileName = "Weapon", menuName = "Item / Weapon", order = int.MaxValue)]
public class Weapon : DropItemBase
{
    [SerializeField]private float _AttackSpeed;
    [SerializeField] WeaponType _weaponType;

    public float WEAPONATTACKSPEED
    {
        get { return _AttackSpeed; }
    }

    public WeaponType WEAPONTYPE
    {
        get { return _weaponType; }
    }

    public override void ItemInit()
    {
        _itemEquipAlready = false;   

        base.ItemInit();
    }



}
