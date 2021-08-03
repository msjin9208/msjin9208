using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<DropItemBase> _inventoryList;


    public List<DropItemBase> PLAYERINVENTORY
	{
        get { return _inventoryList; }
	}

    // Start is called before the first frame update
    void Start()
    {
        _inventoryList = new List<DropItemBase>();
        DropItemBase dropitem = new DropItemBase();
        _inventoryList.Add(dropitem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
