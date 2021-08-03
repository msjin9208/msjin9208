using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    [SerializeField] Button _inventorySlot;
    [SerializeField] GameObject _rectOfInventory;
    [SerializeField] GameObject _rectOfItemInfo;

    private List<Button> _inventorySlotList;
    private void Start()
    {
        _inventorySlotList = new List<Button>();
        _rectOfItemInfo.SetActive(false);
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);
        SetInventoryItem();
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

    private void SetInventoryItem()
    {
        
        for(int i = 0; i < 72; i++)
        {
            var obj = GameObject.Instantiate(_inventorySlot, _rectOfInventory.transform);

            _inventorySlotList.Add(obj);
            _inventorySlotList[i].GetComponent<InventorySlot>().SlotInit(null);
        }

        var playerInventoryList = GameManager.Instance.PLAYER.GetComponent<PlayerInventory>().PLAYERINVENTORY;
        for (int i = 0; i < playerInventoryList.Count; i++)
		{
            playerInventoryList[i].ItemInit();
            _inventorySlotList[i].GetComponent<InventorySlot>().
                SlotInit(playerInventoryList[i]);
            var itemBase = _inventorySlotList[i].GetComponent<InventorySlot>().ITEMINFO;
            _inventorySlotList[i].onClick.AddListener(() => OnClickFunction(itemBase));
        }

    }

    private void OnClickFunction(DropItemBase itemBase)
    {
        _rectOfItemInfo.SetActive(true);


        var image = _rectOfItemInfo.GetComponentsInChildren<Image>();
        image[2].sprite = itemBase.ITEMIMAGE;
        var texts = _rectOfItemInfo.GetComponentsInChildren<Text>();
        texts[0].text = itemBase.ITEMNAME;
        texts[1].text = string.Format("Item Value : " + itemBase.ITEMFUNCTIONVALUE.ToString());
        texts[2].text = string.Format("Price : " + itemBase.ITEMPRICE.ToString());

        var buttons = _rectOfItemInfo.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(()=> itemBase.ItemUse(itemBase.ITEMUSED, itemBase));
        buttons[1].onClick.AddListener(itemBase.ItemDestroy);
        buttons[2].onClick.AddListener(() => _rectOfItemInfo.SetActive(false));
    }
}
