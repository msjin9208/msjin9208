using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SceneEnter(SceneBase scene)
    {
        SceneMgr.Instance.ChangeNextScene(scene);
    }
    public virtual void ScenePreviewEnter()
    {
        SceneMgr.Instance.ChangePreviewScene();
    }
}
