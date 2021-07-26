using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    [SerializeField] GameObject _panel;

    private void Start()
    {
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);

        GameManager.Instance.PLAYER.GetComponent<PlayerBase>().PlayerInfo._info._playerGold += 10;
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            var itembase = ResourceManager.Instance.ItemBase;
            itembase.GetComponent<ItemBase>().SetItem(null, "제발 성공해라!!!", 1000);
            var obj2 = GameObject.FindGameObjectWithTag("SceneUI");

            Debug.Log(obj2.name);
            GameObject.Instantiate(itembase, obj2.transform);
        }
    }
}
