using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : SceneBase
{
    GameObject _player;

    public override void InitScene()
    {
        base.InitScene();
        _sceneName = SCENENAME.Lobby;
        _player = GameManager.Instance.PLAYER;
        _player.SetActive(true);
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

    public override void ResourceLoad()
    {
        base.ResourceLoad();
    }
}
