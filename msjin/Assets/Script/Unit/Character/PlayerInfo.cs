using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERJOB
{
    Citizen,
    Warrior,
    Magic,
    Thief
}

public struct Info
{
    public string _playerNickName;
    public PLAYERJOB _playerJob;
    public int _playerLevel;
    public int _playerGold;

}

public class PlayerInfo
{
    public Info _info;

    public PlayerInfo()
    {
        _info._playerNickName = "Player";
        _info._playerJob = PLAYERJOB.Citizen;
        _info._playerLevel = 1;
        _info._playerGold = 100;

        Messenger.AddListener<int, ITEMFUNCTION, float>(Definition.PlayerPurchase, ItemPurchase);
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemEquip, SelectJob);
        Messenger.AddListener<DropItemBase>(Definition.PlayerItemUnEquip, InitJob);

    }

    private void ItemPurchase(int price, ITEMFUNCTION itemFunc, float value)
    {
        _info._playerGold -= price;
        var ui = GameObject.FindGameObjectWithTag("SceneUI");

        GameManager.Instance.PLAYER.GetComponent<PlayerBase>().UpdatePlayerStateForItem(itemFunc, value);
        Messenger.Broadcast(Definition.RefreshPlayerInfo);
    }
    private void SelectJob(DropItemBase item)
    {
        var weapon = (Weapon)item;

        switch(weapon.WEAPONTYPE)
        {
            case WeaponType.Axe:
                _info._playerJob = PLAYERJOB.Warrior;
                break;
            case WeaponType.Bow:
                _info._playerJob = PLAYERJOB.Thief;
                break;
            case WeaponType.Wand:
                _info._playerJob = PLAYERJOB.Magic;
                break;
        }

        Messenger.Broadcast(Definition.RefreshPlayerInfo);
    }
    private void InitJob(DropItemBase item)
    {
        _info._playerJob = PLAYERJOB.Citizen;
        Messenger.Broadcast(Definition.RefreshPlayerInfo);
    }
}
