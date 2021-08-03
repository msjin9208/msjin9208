using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StoreSceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    Store _store;
    private List<ItemBase> _storeItemList;
    private Dictionary<ITEMFUNCTION, float> _playerInfo;
    private Button[] _playerInfoButton;

    private void Start()
    {
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);

        _store = (Store)SceneMgr.Instance.CURRENTSCENE;
        _storeItemList = _store.ITEMLIST;
        _playerInfo = _store.PLAYERSTOREINFO;
        _playerInfoButton = new Button[5];
        SetStoreItem();
        SetPlayerInfo();

        Messenger.AddListener<ITEMFUNCTION, float>(Definition.RefreshPlayerInfoInStore, RefreshPlayerInfoButton);
        base.SceneUIInit();
    }

    public override void SceneEnter(SceneBase scene)
    {
        SceneUIInit();
        base.SceneEnter(scene);
    }
    public override void ScenePreviewEnter()
    {
        base.ScenePreviewEnter();
    }

    private void Update()
    {

    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(Definition.RefreshPlayerInfo, RefreshPlayerInfo);
        Messenger.RemoveListener<ITEMFUNCTION, float>(Definition.RefreshPlayerInfoInStore, RefreshPlayerInfoButton);
    }

    private void SetStoreItem()
    {
        var panel = GameObject.FindGameObjectWithTag("FunctionPanel");
        for (int i = 0; i < _storeItemList.Count; i++)
        {
            var obj = ResourceManager.Instance.ItemBase;
            var obj2 = GameObject.Instantiate(obj, panel.transform);
            _storeItemList[i].ItemSetObject(obj2);
        }
    }

    private void SetPlayerInfo()
    {
        var panel = GameObject.FindGameObjectWithTag("FunctionPanel");
        for (int i = 0; i < _playerInfo.Count; i++)
        {
            var obj = ResourceManager.Instance.ItemBase;
            var obj2 = GameObject.Instantiate(obj, panel.transform);
            _playerInfoButton[i] = obj2;
        }

        SetPlayerButton();
    }

    private void SetPlayerButton()
    {
        var etor = _playerInfo.GetEnumerator();
        int index = 0;
        while(etor.MoveNext())
        {
            var itemText = _playerInfoButton[index].GetComponentsInChildren<Text>();
            var text = etor.Current.Key;
            var text2 = etor.Current.Value;

            itemText[0].text = text.ToString();
            itemText[1].text = text2.ToString();

            index++;
        }
    }

    private void RefreshPlayerInfoButton(ITEMFUNCTION itemFunc, float value)
    {
        if (_playerInfo== null)
            return;
        
        _playerInfo.Keys.ToList().ForEach(key =>
        {
            if (key == itemFunc)
            {
                _playerInfo[key] = value;
            }
        });

        SetPlayerButton();
    }


}

