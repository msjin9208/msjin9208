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
    private bool _onClickItem;

    Sprite _itemImage = null;
    [SerializeField] Image _dotImage;

    #region 프로퍼티
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
    #endregion

    public void SlotInit(int index)
    {
        _slotIndex = index;

        _itemInfo = null;
        _itemAmount = 0;
        _itemImage = null;
        _dotImage.gameObject.SetActive(false);
    }

    #region 세팅 슬롯
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
            image[1].sprite = _itemImage;
            image[1].color = imagecolor;
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
    #endregion

    #region 클릭 이벤트
    public void OnPointerClick(PointerEventData eventData)
    {
        bool popOn = UIAnimation.Instance.YESORNOPOPUP;
        if (popOn == true)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("클릭클릭!!");

           

            if (_itemInfo != null)
            {
                var slotImage = GetComponentsInChildren<Image>();
                var color = slotImage[1].color;
                color.a = 0.5f;
                slotImage[1].color = color;
                slotImage[1].sprite = _itemImage;

                Debug.Log(_itemInfo.GETITEMNAME);
                Messenger.Broadcast(Definition.InventoryItemInfoOn, this);
            }
        }
    }
    #endregion

    #region 아이템 삭제
    public void RemoveItem()
    {
        if (_itemInfo == null )
            return;

        if (_itemInfo.GETITEMEQUIPALREADY == true)
            Messenger.Broadcast(Definition.PlayerItemUnEquip, _itemInfo);

        if(_itemInfo.GETSTACK == true)
        {
            _itemAmount++;
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
    #endregion

    #region 이미지 세팅
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
    #endregion
}
