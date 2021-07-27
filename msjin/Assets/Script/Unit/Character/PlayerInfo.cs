using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERJOB
{
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
        _info._playerNickName = "Mun Su Jin";
        _info._playerJob = PLAYERJOB.Warrior;
        _info._playerLevel = 1;
        _info._playerGold = 10;
    }

    public void ItemPurchase(int price)
    {
        _info._playerGold -= price;
    }
}
