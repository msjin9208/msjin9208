using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonSceneUI : BaseUI
{
    [SerializeField] Button _backBtn;
    // Start is called before the first frame update
    void Start()
    {
        SceneUIInit();
    }

    // Update is called once per frame
    void Update()
    {
        
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
