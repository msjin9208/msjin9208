using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

public class ResourceManager : MonoBehaviour
{
    static public ResourceManager Instance;


    [SerializeField] public GameObject Player;
    [SerializeField] GameObject Monster;
    [SerializeField] GameObject MonsterPosition;
    [SerializeField] public Button ItemBase;

    [SerializeField] public Sprite weaponSprite;
    [SerializeField] public Sprite armorSprite;


    [SerializeField]private Dictionary<string, DropItemBase> _weaponDic;

    public Dictionary<string, DropItemBase> WEAPONITEM
    {
        get { return _weaponDic; }
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _weaponDic = new Dictionary<string, DropItemBase>();
        WeaponSetting();
        DontDestroyOnLoad(gameObject);
    }

    public void ResoureLoad<T>(string addressable , T arg)
    {
        StartCoroutine(Load(addressable, arg));
    }
    
    private IEnumerator Load<T>(string addressable, T arg)
    {
        Addressables.LoadAssetAsync<T>(addressable).Completed += 
            (rescource)=>
            {
                arg = rescource.Result;
            };
        
        return new WaitUntil(()=>  arg != null);
    }

    private void WeaponSetting()
    {
        var weapons = Resources.LoadAll("Item/Weapon");
        for(int i = 0; i < weapons.Length; i++)
        {
            _weaponDic.Add(weapons[i].name, (DropItemBase)weapons[i]);
        }

        var etor = _weaponDic.GetEnumerator();
        while(etor.MoveNext())
        {
            etor.Current.Value.ItemInit();
        }
    }
}
