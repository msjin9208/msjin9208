using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static public BattleManager Instance;

    private List<UnitBase> _stageMonsterInfo;
    private Dictionary<string, MonsterScripterable> _monsterDic;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;


        _monsterDic = new Dictionary<string, MonsterScripterable>();
        LoadMonsterData();
        DontDestroyOnLoad(gameObject);
    }

    public void StageBattleSetting(List<UnitBase> stageMonster)
    {
        _stageMonsterInfo = stageMonster;
    }

    private void LoadMonsterData()
    {
        var monsters = Resources.LoadAll("Monster");
        for(int i = 0; i < monsters.Length; i++)
        {
            _monsterDic.Add(monsters[i].name, (MonsterScripterable)monsters[i]);
        }

        var etor = _monsterDic.GetEnumerator();
        while(etor.MoveNext())
        {
            etor.Current.Value.MonsterInit();
        }
    }
}
