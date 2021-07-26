using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    private void Start()
    {
        SceneUIInit();
    }
    public override void SceneUIInit()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);

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
}
