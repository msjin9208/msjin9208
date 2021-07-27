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
        itembase.GetComponent<ItemBase>().SetItem(null, "���� �����ض�", 1000);
        var obj2 = GameObject.FindGameObjectWithTag("SceneUI");

        Debug.Log(obj2.name);
        GameObject.Instantiate(itembase, obj2.transform);
     }


    //����
    // ���߿� ������ ���ݸ��� ��ư ������ �ƿ� �ҷ��;� ��
    public override void purchase(int itemPrice)
    {
        var player = GameManager.Instance.PLAYER;
        var playerGold = player.GetComponent<PlayerBase>().PlayerInfo._info._playerGold;
        if(itemPrice > playerGold)
        {
            Debug.Log(playerGold);
            UIAnimation.Instance.FailUI("���� �ݾ� �������� ���� �Ұ�!");
        }
        else
        {
            UIAnimation.Instance.FailUI("���� ����!!!");
            player.GetComponent<PlayerBase>().PlayerInfo.ItemPurchase(itemPrice);
        }
    }
}
