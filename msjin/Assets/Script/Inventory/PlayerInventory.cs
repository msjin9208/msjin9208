using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerInventory : MonoBehaviour
{
    private InventorySlot[] _inventoryItem;
    private int _stackMaxSize = 20;

    private void Start()
    {
        Messenger.AddListener(Definition.InventorySort, InventorySort);
    }

    public void InventoryInit(GameObject bag)
    {
        var bagLength = bag.GetComponentsInChildren<InventorySlot>().Length;
        _inventoryItem = new InventorySlot[bagLength];
        _inventoryItem = bag.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < _inventoryItem.Length; i++)
        {
            _inventoryItem[i].SlotInit(i);
            _inventoryItem[i].SetItemInInventory(null);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DropItemBase weapon = new Weapon();
            DropItemBase armor = new Armor();
            weapon.ItemInit(ResourceManager.Instance.weaponSprite, "Weapon Of Axe", Random.Range(10, 100), Random.Range(10, 100), 1, ItemType.Weapon);
            armor.ItemInit(ResourceManager.Instance.armorSprite, "Armor Of A", Random.Range(10, 100), Random.Range(10, 100), 1, ItemType.Armor);
            GetItem(weapon);
            GetItem(armor);
        }
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

        _inventoryItem[index].SetItemInInventory(item);
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
        return 100;
    }

    private void InventorySort()
    {
        InventorySlot lastSlot = null;
        int emptySlotIndex = FindEmptySlot();
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO != null)
            {
                lastSlot = _inventoryItem[i];
            }
        }

        if (lastSlot == null)
            return;

        if(lastSlot.SLOTINDEX > emptySlotIndex)
        {
            for(int i = emptySlotIndex; i < lastSlot.SLOTINDEX; i++)
            {
                var image = _inventoryItem[i].ITEMIMAGE;
                _inventoryItem[i + 1].ITEMIMAGE = image;

                var info = _inventoryItem[i].ITEMINFO;
                _inventoryItem[i].ITEMINFO = _inventoryItem[i + 1].ITEMINFO;
                _inventoryItem[i + 1].ITEMINFO = info;

                _inventoryItem[i].SetItemInInventory(_inventoryItem[i].ITEMINFO);
                _inventoryItem[i + 1].SetItemInInventory(_inventoryItem[i + 1].ITEMINFO);
            }
        }
    }

    private void OnDestroy()
    {
        Messenger.AddListener(Definition.InventorySort, InventorySort);
    }
}
