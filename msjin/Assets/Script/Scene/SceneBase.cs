using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SCENENAME
{
    Game,
    Lobby,
    Dungeon,
    Inventory,
    Store
}

public class SceneBase
{
    protected SCENENAME  _sceneName;

    public virtual void InitScene()
    {
        Messenger.AddListener(Definition.EnterScene, EnterScene);
        Messenger.AddListener(Definition.ExitScene, ExitScene);
        Messenger.AddListener(Definition.ResoureLoad, ResourceLoad);
    }

    public virtual void EnterScene()
    {
        //Messenger.Broadcast(Definition.RefreshPlayerInfo);
        //ResourceLoad();
    }
    public virtual void ExitScene()
    {
        Messenger.RemoveListener(Definition.EnterScene, EnterScene);
        Messenger.RemoveListener(Definition.ExitScene, ExitScene);
        Messenger.RemoveListener(Definition.ResoureLoad, ResourceLoad);

        
        Messenger.Broadcast(Definition.PlayerOut);
        Messenger.Broadcast(Definition.FadeOut);
        //PlayerEntry.Instance.PlayerOut();
        //UIAnimation.Instance.FadeOut();
    }
    public virtual SCENENAME Scene()
    {
        return _sceneName;
    }
    public virtual void ResourceLoad()
    {
        Messenger.Broadcast(Definition.PlayerEnter);
        Messenger.Broadcast(Definition.FadeIn);
        Messenger.Broadcast(Definition.RefreshPlayerInfo);
        //PlayerEntry.Instance.PlayerEnter();
        //UIAnimation.Instance.FadeIn();
    }
}
