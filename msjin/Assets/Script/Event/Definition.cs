using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definition
{
    //Scene 관련
    public const string RefreshPlayerInfo = "RefreshPlayerInfo";
    public const string LoadScene = "LoadScene";
    public const string EnterScene = "EnterScene";
    public const string ExitScene = "ExitScene";
    public const string ResoureLoad = "ResoureLoad";

    //UI 애니메이션 관련
    public const string FadeIn = "FadeIn";
    public const string FadeOut = "FadeOut";
    public const string PlayerEnter = "PlayerEnter";
    public const string PlayerOut = "PlayerOut";

    //플레이어 아이템 구입
    public const string PlayerPurchase = "PlayerPurchase";
    public const string RefreshPlayerInfoInStore = "RefreshPlayerInfoInStore";

    //플레이어 아이템 사용
    public const string PlayerItemEquip = "PlayerItemUsed";
    public const string PlayerItemUnEquip = "PlayerItemUnEquip";
    public const string UsePotion = "UsePotion";
    public const string UseEquipItemRankUp = "UseEquipItemRankUp";

    //인벤토리
    public const string InventorySort = "InventorySort";
    public const string InventorySceneEnter = "InventorySceneEnter";
    

    //팝업
    public const string YesOrNoPOPUP = "YesOrNoPOPUP";
    public const string InventoryItemInfoOn = "InventoryItemInfoOn";

    //던전
    public const string SetMonster = "SetMonster";
    public const string MonsterEntry = "MonsterEntry";
}
