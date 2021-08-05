using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    [SerializeField] GameObject _bag;
    [SerializeField] GameObject _ItemInfoMenu;
    [SerializeField] Canvas _sceneCanvas;

    private List<Button> _inventorySlotList;
    private InventorySlot _currenSlot;



    private void Start()
    {
        _currenSlot = null;
        _inventorySlotList = new List<Button>();
        GameManager.Instance.PLAYER.GetComponent<PlayerInventory>().InventoryInit(_bag);
        _ItemInfoMenu.SetActive(false);
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);
        Messenger.AddListener<InventorySlot>(Definition.InventoryItemInfoOn, OnClickFunction);


        base.SceneUIInit();
    }

    public override void SceneEnter(SceneBase scene)
    {
        base.SceneEnter(scene);

        SceneUIInit();
    }
    public override void ScenePreviewEnter()
    {
        base.ScenePreviewEnter();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(Definition.RefreshPlayerInfo, RefreshPlayerInfo);
        _inventorySlotList = null;
    }

    private void OnClickFunction(InventorySlot slot)
    {
        InventorySlot _prevSlot = null;
        if (_currenSlot != slot && _currenSlot != null && _currenSlot.ITEMINFO.GETITEMEQUIPALREADY == false)
        {
            _currenSlot.UnEquipImageSetting();
        }

        if(_currenSlot != null)
        {
            _prevSlot = _currenSlot;
        }
        _currenSlot = slot;

        var popup = _ItemInfoMenu;
        popup.SetActive(true);
        var item = _currenSlot.ITEMINFO;

        var image = popup.GetComponentsInChildren<Image>();
        image[2].sprite = item.GETITEMIMAGE;
        var texts = popup.GetComponentsInChildren<Text>();
        texts[0].text = item.GETITEMNAME;
        texts[1].text = string.Format("Item Value : " + item.GETITEMFUNCTIONVALUE.ToString());
        texts[2].text = string.Format("Price : " + item.GETITEMPRICE.ToString());

        var buttons = popup.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }

        buttons[0].onClick.AddListener(() => {
            if (item.GETITEMEQUIPALREADY == true)
            {
                Messenger.Broadcast(Definition.PlayerItemUnEquip, item);
                _currenSlot.UnEquipImageSetting();
            }
            else
            {
                if (_prevSlot != null
                    && _prevSlot.ITEMINFO.GETITEMEQUIPALREADY == true
                    && _prevSlot.ITEMINFO.GETITEMTYPE == _currenSlot.ITEMINFO.GETITEMTYPE)
                {
                    _prevSlot.UnEquipImageSetting();
                }

                Messenger.Broadcast(Definition.PlayerItemUsed, item);
                _currenSlot.EquipImageSetting();
            }
                
            popup.SetActive(false);
        });

        buttons[1].onClick.AddListener(()=> {
            var text = "아이템을 삭제하시겠습니까?";
            Messenger.Broadcast(Definition.YesOrNoPOPUP, text, _currenSlot);
            
            popup.SetActive(false);
        });

        buttons[2].onClick.AddListener(() =>
        {
            _currenSlot.UnEquipImageSetting();
            popup.SetActive(false);
        });
    }
}
