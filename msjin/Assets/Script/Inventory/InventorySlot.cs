using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    DropItemBase _itemInfo = null;
    private int _itemAmount = 0;
    private int _slotIndex = 0;
    private bool _uiOn;

    Sprite _itemImage = null;
    [SerializeField] Image _dotImage;

    public DropItemBase ITEMINFO
    {
        get { return _itemInfo; }
        set { _itemInfo = value; }
    }
    public int ITEMAMOUNT
    {
        get { return _itemAmount; }
        set { _itemAmount = value; }
    }
    public int SLOTINDEX
    {
        get { return _slotIndex; }
    }
    public Sprite ITEMIMAGE
    {
        get { return _itemImage; }
        set { _itemImage = value; }
    }


    public void SlotInit(int index)
    {
        _slotIndex = index;

        _itemInfo = null;
        _itemAmount = 0;
        _itemImage = null;
        _dotImage.gameObject.SetActive(false);
    }

    public void SetItemInInventory(DropItemBase item)
    {
        if(item == null)
        {
            _itemInfo = null;
            _itemImage = null;
            _itemAmount = 0;

            var image = GetComponentsInChildren<Image>();
            var imagecolor = image[1].color;
            imagecolor.a = 0;
            image[1].color = imagecolor;
            image[1].sprite = _itemImage;

            UnEquipImageSetting();

            return;
        }

        _itemInfo = item;
        _itemImage = item.GETITEMIMAGE;

        var slotImage = GetComponentsInChildren<Image>();
        var color = slotImage[1].color;
        color.a = 1;
        slotImage[1].color = color;
        slotImage[1].sprite = _itemImage;

        if (item.GETSTACK == true)
        {
            var text = GetComponentInChildren<Text>();
            text.text = _itemAmount.ToString();
        }
        else
        {
            var text = GetComponentInChildren<Text>();
            text.text = "";
        }

        if(_itemInfo.GETITEMEQUIPALREADY)
        {
            EquipImageSetting();
        }
        else
        {
            UnEquipImageSetting();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool popOn = UIAnimation.Instance.YESORNOPOPUP;
        if (popOn == true)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("클릭클릭!!");

            var slotImage = GetComponentsInChildren<Image>();
            var color = slotImage[1].color;
            color.a = 0.5f;
            slotImage[1].color = color;
            slotImage[1].sprite = _itemImage;

            if (_itemInfo != null)
            {
                Debug.Log(_itemInfo.GETITEMNAME);
                Messenger.Broadcast(Definition.InventoryItemInfoOn, this);
            }
        }
    }

    public void RemoveItem()
    {
        if (_itemInfo == null)
            return;

        if (_itemInfo.GETITEMEQUIPALREADY == true)
            Messenger.Broadcast(Definition.PlayerItemUnEquip, _itemInfo);

        if(_itemInfo.GETSTACK == true)
        {
            _itemInfo.GETITEMAMOUNT--;
            return;
        }

        _itemAmount= 0;
        _itemInfo = null;
        _itemImage = null;
        _dotImage.gameObject.SetActive(false);

        var slotImage = GetComponentsInChildren<Image>();
        var color = slotImage[1].color;
        color.a = 0;
        slotImage[1].color = color;
        slotImage[1].sprite = _itemImage;

        Messenger.Broadcast(Definition.InventorySort);
    }

    public void EquipImageSetting()
    {
        _dotImage.gameObject.SetActive(true);
        var slotImage = GetComponentsInChildren<Image>();
        var color = slotImage[1].color;
        color.a = 0.5f;
        slotImage[1].color = color;
        slotImage[1].sprite = _itemImage;
    }
    public void UnEquipImageSetting()
    {
        _dotImage.gameObject.SetActive(false);
        var slotImage = GetComponentsInChildren<Image>();
        var color = slotImage[1].color;
        color.a = 1;
        slotImage[1].color = color;
        slotImage[1].sprite = _itemImage;
    }
}
