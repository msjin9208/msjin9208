using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    private void Start()
    {
        _backBtn.onClick.AddListener(ScenePreviewEnter);
    }
    public override void SceneEnter(SceneBase scene)
    {
        base.SceneEnter(scene);
    }
    public override void ScenePreviewEnter()
    {
        base.ScenePreviewEnter();
    }
}
