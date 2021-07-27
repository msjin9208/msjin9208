using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    [SerializeField] public Sprite _itemImage;
    public string _itemName;
    public int _itemPrice;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetItem(Sprite itemImage, string itemName, int itemPrice)
    {
        var image = GetComponentsInChildren<Image>();

        for(int i = 0; i < image.Length; i++)
            if (image[i].name == "ItemImage")
                image[i].sprite = _itemImage;

        //gameObject.GetComponentsInChildren<Image>().sprite = _itemImage;
        var itemText = gameObject.GetComponentsInChildren<Text>();

        itemText[0].text = itemName;
        itemText[1].text = itemPrice.ToString();
    }

}
