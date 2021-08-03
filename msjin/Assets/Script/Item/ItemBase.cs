using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ITEMFUNCTION
{
    Hp,
    Mp,
    Attack,
    Defence,
    AttackSpeed
}

public class ItemBase
{
    [SerializeField] protected Sprite _itemImage;

    protected string _itemName;
    protected int _itemPrice;
    protected float _itemFunctionValue;
    protected ITEMFUNCTION _itemFuncion;

    protected Button _itemObject;



    public Button _ITEMBUTTON
    {
        get { return _itemObject; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void ItemPurchase()
    {

    }

    public virtual void ItemInit(Sprite itemImage, string itemName, int itemPrice, ITEMFUNCTION itemfunc)
    {
     
    }

    public virtual void ItemSetObject(Button obj)
    {
        _itemObject = obj;
        _itemObject.onClick.AddListener(ItemPurchase);
        //_itemObject.GetComponent<Button>().onClick.AddListener(ItemPurchase);

        var findImage = _itemObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < findImage.Length; i++)
        {
            if (findImage[i].name == "ItemImage")
                findImage[i].sprite = _itemImage;
        }

        var itemText = _itemObject.GetComponentsInChildren<Text>();
        itemText[0].text = _itemName;
        itemText[1].text = _itemPrice.ToString();
    }

    protected void RefreshItem()
    {
        var itemText = _itemObject.GetComponentsInChildren<Text>();
        itemText[0].text = _itemName;
        itemText[1].text = _itemPrice.ToString();
    }
}
