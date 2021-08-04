using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    DropItemBase _itemInfo = null;
    private int _itemAmount = 0;

    Sprite _itemImage;

    public DropItemBase ITEMINFO
    {
        get { return _itemInfo; }
    }
    public int ITEMAMOUNT
    {
        get { return _itemAmount; }
        set { _itemAmount = value; }
    }

    public void SlotInit(DropItemBase item)
    {
        _itemInfo = item;
        _itemImage = item.GETITEMIMAGE;

        var slotImage = GetComponentsInChildren<Image>();
        var color = slotImage[1].color;
        color.a = 1;
        slotImage[1].color = color;
        slotImage[1].sprite = _itemImage;

        if(item.GETSTACK == true)
        {
            var text = GetComponentInChildren<Text>();
            text.text = _itemAmount.ToString();
        }
        else
        {
            var text = GetComponentInChildren<Text>();
            text.text = "";
        }
    }

    public void RemoveItem()
    {
        if (_itemInfo == null)
            return;

        _itemInfo = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("클릭클릭!!");
            if (_itemInfo != null)
            {
                Debug.Log(_itemInfo.GETITEMNAME);
                Messenger.Broadcast(Definition.InventoryItemInfoOn, this);
            }
        }
    }
}
