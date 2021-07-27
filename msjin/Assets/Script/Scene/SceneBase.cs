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
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void InitScene()
    {
       
    }

    public virtual void EnterScene()
    {
        
    }
    public virtual void ExitScene()
    {
        PlayerEntry.Instance.PlayerOut();
        UIAnimation.Instance.FadeOut();
    }
    public virtual SCENENAME Scene()
    {
        return _sceneName;
    }
    public virtual void ResourceLoad()
    {
        UIAnimation.Instance.FadeIn();
        PlayerEntry.Instance.PlayerEnter();
    }


    //ªË¡¶
    public virtual void purchase(int itemPrice)
    {

    }
}
