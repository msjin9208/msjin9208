using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerInventory : MonoBehaviour
{
    private InventorySlot[] _inventoryItem;
    private int _stackMaxSize = 20;

    public void InventoryInit(GameObject bag)
    {
        var bagLength = bag.GetComponentsInChildren<InventorySlot>().Length;
        _inventoryItem = new InventorySlot[bagLength];
        _inventoryItem = bag.GetComponentsInChildren<InventorySlot>();

        DropItemBase weapon = new Weapon();
        DropItemBase armor = new Armor();
        weapon.ItemInit(ResourceManager.Instance.weaponSprite, "Weapon Of Axe", Random.Range(10,100), Random.Range(10, 100), 1, ItemType.Weapon);
        armor.ItemInit(ResourceManager.Instance.armorSprite, "Armor Of A", Random.Range(10, 100), Random.Range(10, 100), 1, ItemType.Armor);
        GetItem(weapon);
        GetItem(armor);
    }

    private void GetItem(DropItemBase item)
    {
        int index = 0;
        if (item.GETSTACK == true)
            index = FindStackItemSlot(item);
        else
            index = FindEmptySlot();

        if (index >= _inventoryItem.Length)
            return;

        _inventoryItem[index].SlotInit(item);
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO !=null)
            {
                Debug.Log(_inventoryItem[i].ITEMINFO.GETITEMNAME);
            }
        }
    }

    private int FindStackItemSlot(DropItemBase item)
    {
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO.GETITEMNAME == item.GETITEMNAME)
            {
                if(_stackMaxSize <= _inventoryItem[i].ITEMAMOUNT)
                {
                    _inventoryItem[i].ITEMAMOUNT++;
                }
            }
        }

        return FindEmptySlot();
    }
    private int FindEmptySlot()
    {
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO == null)
            {
                return i;
            }
        }
        return 26;
    }

    private void SortInventory()
    {

    }

 
}
