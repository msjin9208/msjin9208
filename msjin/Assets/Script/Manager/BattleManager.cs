using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static public BattleManager Instance;

    private List<GameObject> _stageMonsterInfo;
    private Dictionary<string, MonsterScripterable> _monsterDic;
    private GameObject _monseter;

    public Dictionary<string, MonsterScripterable> MONSTERDIC
    {
        get { return _monsterDic; }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        
        _monsterDic = new Dictionary<string, MonsterScripterable>();
        LoadMonsterData();

        Messenger.AddListener(Definition.SetMonster, SetStageMonster);
        DontDestroyOnLoad(gameObject);
    }

    public void StageBattleSetting(List<GameObject> stageMonster)
    {
        if(_stageMonsterInfo != null)
            _stageMonsterInfo = null;

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

    private void SetStageMonster()
    {
        if (_stageMonsterInfo == null)
            return;

        _monseter = null;
        var etor = _stageMonsterInfo.GetEnumerator();
        while(etor.MoveNext())
        {
            var obj = etor.Current;
            var death = obj.GetComponent<MonsterBase>().MONSTERDEATH;

            if (death == false)
            {
                _monseter = GameObject.Instantiate(obj);
                _monseter.SetActive(false);
                Messenger.Broadcast(Definition.MonsterEntry, _monseter);
                break;
            }
        }

        if(_monseter == null)
        {
            return;
        }
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(Definition.SetMonster, SetStageMonster);
    }
}
