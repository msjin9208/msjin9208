using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon : SceneBase
{
    public override void InitScene()
    {
        base.InitScene();
        _sceneName = SCENENAME.Dungeon;
    }

    public override void EnterScene()
    {
        //InitScene();
        

        base.EnterScene();
    }

    public override void ExitScene()
    {
        base.ExitScene();
    }
}
