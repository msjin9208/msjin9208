using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDungeon : SceneBase
{
    public override void InitScene()
    {
        base.InitScene();
        _sceneName = SCENENAME.InDungeon;
    }
    public override void EnterScene()
    {
        base.EnterScene();

        Messenger.Broadcast(Definition.SetMonster);
    }

    public override void ExitScene()
    {
        base.ExitScene();
    }
    public override void ResourceLoad()
    {
        base.ResourceLoad();
    }

    public override SCENENAME Scene()
    {
        return base.Scene();
    }

}
