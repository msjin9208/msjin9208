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

        DropItemBase dropItem = new Weapon();
        DropItemBase dropItem1 = new Weapon();
        dropItem.ItemInit(null, "Weapon Of Axe", Random.Range(10,100), Random.Range(10, 100), 1);
        dropItem1.ItemInit(null, "Axe Of Weapon", Random.Range(10, 100), Random.Range(10, 100), 1);
        GetItem(dropItem);
        GetItem(dropItem1);
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
