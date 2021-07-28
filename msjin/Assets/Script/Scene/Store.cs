using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : SceneBase
{
    public List<ItemBase> _itemList;
    
    public override void InitScene()
    {
        base.InitScene();
        _itemList = new List<ItemBase>();

        ItemBase item = new StoreItem();
        item.ItemInit(default, "첫번째 아이템", 10, ITEMFUNCTION.Attack);
        ItemBase item2 = new StoreItem();
        item2.ItemInit(default, "두번째 아이템", 20, ITEMFUNCTION.AttackSpeed);

        _itemList.Add(item);
        _itemList.Add(item2);


        //_itemList = new List<Button>();
        //var item = ResourceManager.Instance.ItemBase;
        //item.GetComponent<ItemBase>().SetItem(default, "구매하자!!", 10, ITEMFUNCTION.Attack);
        //_itemList.Add(item);
        //item.GetComponent<ItemBase>().SetItem(default, "두번째꺼다!!!!", 10, ITEMFUNCTION.Defence);
        //_itemList.Add(item);

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

    public override void ResourceLoad()
    {
        var panel = GameObject.FindGameObjectWithTag("FunctionPanel");
        for(int i = 0; i < _itemList.Count; i++)
        {
            var obj = ResourceManager.Instance.ItemBase;
            var obj2 = GameObject.Instantiate(obj, panel.transform);
            _itemList[i].ItemSetObject(obj2);
        }

        base.ResourceLoad();
    }
}
