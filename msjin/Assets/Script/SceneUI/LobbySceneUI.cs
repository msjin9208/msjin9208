using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySceneUI : BaseUI
{
    [SerializeField] Button _dungeonBtn;
    [SerializeField] Button _inventoryBtn;
    [SerializeField] Button _storeBtn;
    [SerializeField] Button _backBtn;

    private Dungeon _dungeon;
    private Inventory _inventory;
    private Store _store;

    // Start is called before the first frame update
    private void Start()
    {
        SceneUIInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SceneUIInit()
    {
        _dungeon = new Dungeon();
        _inventory = new Inventory();
        _store = new Store();

        _dungeonBtn.onClick.AddListener(() => SceneEnter(_dungeon));
        _inventoryBtn.onClick.AddListener(() => SceneEnter(_inventory));
        _storeBtn.onClick.AddListener(() => SceneEnter(_store));
        _backBtn.onClick.AddListener(SceneMgr.Instance.ChangePreviewScene);

        base.SceneUIInit();
    }

    public override void SceneEnter(SceneBase scene)
    {
        base.SceneEnter(scene);
    }
    public override void ScenePreviewEnter()
    {
        base.ScenePreviewEnter();
    }

    private void OnDestroy()
    {
        _dungeon = null;
        _inventory = null;
        _store = null;
    }


}
