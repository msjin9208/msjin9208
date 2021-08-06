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

    //private List<Button> _inventorySlotList;
    private InventorySlot _currenSlot;



    private void Start()
    {
        _currenSlot = null;
        //_inventorySlotList = new List<Button>();
        

        _ItemInfoMenu.SetActive(false);
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(()=> 
        { 
            Messenger.Broadcast(Definition.InventorySceneEnter, _sceneCanvas);
            ScenePreviewEnter();
        });


		//메시지 등록
        Messenger.Broadcast(Definition.InventorySceneEnter, _sceneCanvas);
		Messenger.AddListener<InventorySlot>(Definition.InventoryItemInfoOn, OnClickFunction);
        //아이템이 삭제 됐을 때 인벤토리 소트해주는 절차에서 현재 갖고 있던 슬롯 정보를 초기화 해준다.;
        Messenger.AddListener(Definition.InventorySort, () => _currenSlot = null);
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



    private void OnClickFunction(InventorySlot slot)
    {
        var popup = _ItemInfoMenu;
        if (_currenSlot != slot && _currenSlot != null && _currenSlot.ITEMINFO.GETITEMEQUIPALREADY == false)
        {
            _currenSlot.UnEquipImageSetting();
        }
        else if(_currenSlot != null && slot == _currenSlot)
        {
            if(_currenSlot.ITEMINFO.GETITEMEQUIPALREADY == false)
                slot.UnEquipImageSetting();
            
            popup.SetActive(false);
            _currenSlot = null;
            return;
        }

        _currenSlot = slot;
        
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
                Messenger.Broadcast(Definition.PlayerItemEquip, item);
                _currenSlot.EquipImageSetting();
                _currenSlot = null;
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



    private void OnDestroy()
    {
        if (_currenSlot != null)
            _currenSlot.UnEquipImageSetting();

        Messenger.RemoveListener(Definition.RefreshPlayerInfo, RefreshPlayerInfo);
        Messenger.RemoveListener<InventorySlot>(Definition.InventoryItemInfoOn, OnClickFunction);
        Messenger.RemoveListener(Definition.InventorySort, () => _currenSlot = null);
    }
}
