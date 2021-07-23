using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : SceneBase
{
    public override void InitScene()
    {
        base.InitScene();
        _sceneName = SCENENAME.Game;
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
