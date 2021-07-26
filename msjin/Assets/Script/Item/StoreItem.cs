using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : ItemBase
{
    // Start is called before the first frame update
    void Start()
    {
        //_itemName = "아무거나";
        //_itemPrice = 100000;

        //var obj = GetComponentInChildren<Sprite>();
        //var objText = GetComponentsInChildren<Text>();

        //obj = _itemImage;
        //objText[0].text = _itemName;
        //objText[1].text = string.Format("Price : " + _itemPrice.ToString());
    }

    public override void SetItem(Sprite itemImage, string itemName, int itemPrice)
    {
        base.SetItem(itemImage, itemName, itemPrice);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
