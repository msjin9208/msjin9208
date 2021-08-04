using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    [SerializeField] GameObject _bag;
    [SerializeField] GameObject _rectOfItemInfo;

    private List<Button> _inventorySlotList;
    private void Start()
    {
        _inventorySlotList = new List<Button>();
        GameManager.Instance.PLAYER.GetComponent<PlayerInventory>().InventoryInit(_bag);
        _rectOfItemInfo.SetActive(false);
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);
        Messenger.AddListener<DropItemBase>(Definition.InventoryItemInfoOn, OnClickFunction);


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

    private void OnClickFunction(DropItemBase itemBase)
    {
        _rectOfItemInfo.SetActive(true);


        var image = _rectOfItemInfo.GetComponentsInChildren<Image>();
        image[2].sprite = itemBase.GETITEMIMAGE;
        var texts = _rectOfItemInfo.GetComponentsInChildren<Text>();
        texts[0].text = itemBase.GETITEMNAME;
        texts[1].text = string.Format("Item Value : " + itemBase.GETITEMFUNCTIONVALUE.ToString());
        texts[2].text = string.Format("Price : " + itemBase.GETITEMPRICE.ToString());

        var buttons = _rectOfItemInfo.GetComponentsInChildren<Button>();
        //buttons[0].onClick.AddListener(() => itemBase.ItemUse(itemBase.ITEMUSED, itemBase));
        //buttons[1].onClick.AddListener(itemBase.ItemDestroy);
        buttons[2].onClick.AddListener(() => _rectOfItemInfo.SetActive(false));
    }
}
