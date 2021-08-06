using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerInventory : MonoBehaviour
{
    private InventorySlot[] _inventoryItem;
    private int _stackMaxSize = 20;
    [SerializeField] GameObject _bag;
    GameObject _cloneBag;

    private void Start()
    {
        Messenger.AddListener(Definition.InventorySort, InventorySort);
        Messenger.AddListener<Canvas>(Definition.InventorySceneEnter, InventorySceneEnter);

        _cloneBag = GameObject.Instantiate(_bag);
        _cloneBag.SetActive(false);
        InventoryInit(_cloneBag);


        _cloneBag.transform.SetParent(GameManager.Instance.PLAYER.transform);
        _cloneBag.SetActive(false);
        //DontDestroyOnLoad(_cloneBag);
        //DontDestroyOnLoad(gameObject);
    }

    private void InventoryInit(GameObject bag)
    {
        if (_inventoryItem != null)
		{
            for(int i = 0; i < _inventoryItem.Length; i++)
			{
                if(_inventoryItem[i].ITEMINFO !=null)
				{
                    _inventoryItem[i].SetItemInInventory(_inventoryItem[i].ITEMINFO);
				}
                else
                {
                    
                    
                    _inventoryItem[i].SetItemInInventory(null);
                }
            }

            return;
		}

        var bagLength = bag.GetComponentsInChildren<InventorySlot>().Length;
        _inventoryItem = new InventorySlot[bagLength];
        _inventoryItem = bag.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < _inventoryItem.Length; i++)
        {
            _inventoryItem[i].SlotInit(i);
            _inventoryItem[i].SetItemInInventory(null);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DropItemBase weapon = new Weapon();
            DropItemBase armor = new Armor();
            weapon.ItemInit(ResourceManager.Instance.weaponSprite, "Weapon Of Axe", Random.Range(10, 100), Random.Range(10, 100), 1, ItemType.Weapon);
            armor.ItemInit(ResourceManager.Instance.armorSprite, "Armor Of A", Random.Range(10, 100), Random.Range(10, 100), 1, ItemType.Armor);
            GetItem(weapon);
            GetItem(armor);
        }
    }

    private void GetItem(DropItemBase item)
    {
        int index = 0;
        if (item.GETSTACK == true)
            index = FindStackItemSlot(item);
        else
            index = FindEmptySlot();

        if (index >= _inventoryItem.Length)
            return;

        _inventoryItem[index].SetItemInInventory(item);
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO !=null)
            {
                Debug.Log(_inventoryItem[i].ITEMINFO.GETITEMNAME);
            }
        }
    }

    private int FindStackItemSlot(DropItemBase item)
    {
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO.GETITEMNAME == item.GETITEMNAME)
            {
                if(_stackMaxSize <= _inventoryItem[i].ITEMAMOUNT)
                {
                    _inventoryItem[i].ITEMAMOUNT++;
                }
            }
        }

        return FindEmptySlot();
    }
    private int FindEmptySlot()
    {
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO == null)
            {
                return i;
            }
        }
        return 100;
    }

    private void InventorySort()
    {
        InventorySlot lastSlot = null;
        int emptySlotIndex = FindEmptySlot();
        for(int i = 0; i < _inventoryItem.Length; i++)
        {
            if(_inventoryItem[i].ITEMINFO != null)
            {
                lastSlot = _inventoryItem[i];
            }
        }

        if (lastSlot == null)
            return;

        if(lastSlot.SLOTINDEX > emptySlotIndex)
        {
            for(int i = emptySlotIndex; i < lastSlot.SLOTINDEX; i++)
            {
                var image = _inventoryItem[i].ITEMIMAGE;
                _inventoryItem[i + 1].ITEMIMAGE = image;

                var info = _inventoryItem[i].ITEMINFO;
                _inventoryItem[i].ITEMINFO = _inventoryItem[i + 1].ITEMINFO;
                _inventoryItem[i + 1].ITEMINFO = info;

                _inventoryItem[i].SetItemInInventory(_inventoryItem[i].ITEMINFO);
                _inventoryItem[i + 1].SetItemInInventory(_inventoryItem[i + 1].ITEMINFO);
            }
        }
    }

    private void InventorySceneEnter(Canvas parents)
	{
		var bagParent = _cloneBag.transform.parent;

		if (bagParent != parents.transform)
		{
			_cloneBag.SetActive(true);
			_cloneBag.transform.SetParent(parents.transform);
			_cloneBag.transform.localPosition = Vector3.zero;
            _cloneBag.transform.localScale = new Vector3(1, 1, 1);
		}
		else
		{
            _cloneBag.transform.SetParent(GameManager.Instance.PLAYER.transform);
            _cloneBag.SetActive(false);
		}

	}
    private void OnDestroy()
    {
        Messenger.AddListener(Definition.InventorySort, InventorySort);
        Messenger.AddListener<Canvas>(Definition.InventorySceneEnter, InventorySceneEnter);
    }
}
