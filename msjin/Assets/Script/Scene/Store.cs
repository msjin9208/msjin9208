using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : SceneBase
{
    private List<ItemBase> _itemList;
    private Dictionary<ITEMFUNCTION, float> _playerInfo;
    
    public List<ItemBase> ITEMLIST
    {
        get { return _itemList; }
    }
    public Dictionary<ITEMFUNCTION, float> PLAYERSTOREINFO
    {
        get { return _playerInfo; }
    }

    public override void InitScene()
    {
        base.InitScene();
        _itemList = new List<ItemBase>();
        _playerInfo = new Dictionary<ITEMFUNCTION, float>();

        ItemBase item = new StoreItem();
        item.ItemInit(default, "Attack UP",10, ITEMFUNCTION.Attack);
        ItemBase item2 = new StoreItem();
        item2.ItemInit(default, "AttackSpeed UP", 10, ITEMFUNCTION.AttackSpeed);
        ItemBase item3 = new StoreItem();
        item3.ItemInit(default, "Defence UP", 10, ITEMFUNCTION.Defence);
        ItemBase item4 = new StoreItem();
        item4.ItemInit(default, "HP UP", 10, ITEMFUNCTION.Hp);
        ItemBase item5 = new StoreItem();
        item5.ItemInit(default, "MP UP", 10, ITEMFUNCTION.Mp);
        
        _itemList.Add(item);
        _itemList.Add(item2);
        _itemList.Add(item3);
        _itemList.Add(item4);
        _itemList.Add(item5);

        var playerInfo = GameManager.Instance.PLAYERBASE;
        _playerInfo.Add(ITEMFUNCTION.Attack, playerInfo.UNITSTATUS._attack);
        _playerInfo.Add(ITEMFUNCTION.AttackSpeed, playerInfo.UNITSTATUS._attackSpeed);
        _playerInfo.Add(ITEMFUNCTION.Defence, playerInfo.UNITSTATUS._defence);
        _playerInfo.Add(ITEMFUNCTION.Hp, playerInfo.UNITSTATUS._hp);
        _playerInfo.Add(ITEMFUNCTION.Mp, playerInfo.UNITSTATUS._mp);

        _sceneName = SCENENAME.Store;
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

    public override SCENENAME Scene()
    {
        return base.Scene();
    }

    public override void ResourceLoad()
    {
        base.ResourceLoad();
    }
}
