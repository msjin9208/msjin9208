using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : SceneBase
{
    public override void InitScene()
    {
        base.InitScene();

        _sceneName = SCENENAME.Game;
        GameManager.Instance.PLAYER.SetActive(false);
    }

    public override void EnterScene()
    {
        //InitScene();
        base.EnterScene();
        Messenger.Broadcast(Definition.FadeIn);
        
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
