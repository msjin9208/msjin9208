using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : SceneBase
{
    public override void InitScene()
    {
        base.InitScene();
        _sceneName = SCENENAME.Store;
    }
    public override void EnterScene()
    {
        InitScene();

        base.EnterScene();
    }
    public override void ExitScene()
    {
        base.ExitScene();
    }
}
