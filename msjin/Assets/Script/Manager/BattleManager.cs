using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static public BattleManager Instance;

    private List<UnitBase> _stageMonsterInfo;
    private Dictionary<string, MonsterScripterable> _monsterDic;
    private GameObject _monseter;

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
        //변경해야 돼 여기서 세팅만 해주고 씬 로드할 때 클론하고 SetActive 해주고 페이드 인 해줘야할 듯

        MonsterScripterable monster;
        _monsterDic.TryGetValue("Orc", out monster);
        _monseter = GameObject.Instantiate(monster.MONSTEROBJECT, new Vector3(0,0,0), Quaternion.identity);

        //_stageMonsterInfo = stageMonster;
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
