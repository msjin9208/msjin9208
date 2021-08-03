using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    DropItemBase _itemInfo;

    public DropItemBase ITEMINFO
    {
        get { return _itemInfo; }
    }

    public void SlotInit(DropItemBase item)
    {
        if (item == null)
        {
            GetComponent<Button>().interactable = false;
            return;
        }

        if(_itemInfo == null)
            _itemInfo = item;


        GetComponent<Button>().interactable = true;
        GetComponentInChildren<RawImage>().texture = _itemInfo.ITEMIMAGE;
    }
}
