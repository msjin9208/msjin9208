using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : SceneBase
{
    public List<ItemBase> _itemList;
    public GameObject obj;
    public override void InitScene()
    {
        base.InitScene();

        _itemList = new List<ItemBase>();
        
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
        base.ResourceLoad();


        //ItemListInit();
    }

    private void ItemListInit()
    {
        var itembase = ResourceManager.Instance.ItemBase;
        itembase.GetComponent<ItemBase>().SetItem(null, "제발 성공해라", 1000);
        var obj2 = GameObject.FindGameObjectWithTag("SceneUI");

        Debug.Log(obj2.name);
        GameObject.Instantiate(itembase, obj2.transform);
     }


    //구매
    // 나중에 아이템 가격말고 버튼 정보를 아예 불러와야 함
    public override void purchase(int itemPrice)
    {
        var player = GameManager.Instance.PLAYER;
        var playerGold = player.GetComponent<PlayerBase>().PlayerInfo._info._playerGold;
        if(itemPrice > playerGold)
        {
            Debug.Log(playerGold);
            UIAnimation.Instance.FailUI("소지 금액 부족으로 구매 불가!");
        }
        else
        {
            UIAnimation.Instance.FailUI("구매 성공!!!");
            player.GetComponent<PlayerBase>().PlayerInfo.ItemPurchase(itemPrice);
        }
    }
}
