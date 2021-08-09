using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static public BattleManager Instance;

    private List<UnitBase> _stageMonsterInfo;
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

 
    }

    public void StageBattleSetting(List<UnitBase> stageMonster)
    {
        _stageMonsterInfo = stageMonster;
    }
}
