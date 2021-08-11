using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterJob
{
    Warrior,
    Thief,
    Magic
}

[CreateAssetMenu(fileName = "Monster", menuName = "Monster / Orc", order = int.MaxValue)]
public class MonsterScripterable : ScriptableObject
{
    [SerializeField] string _monsterName;
    [SerializeField] GameObject _monster;
    [SerializeField] int _monsterLevel;
    [SerializeField] MonsterJob _monsterJob;
    MonsterBase _monsterBase;
    
    public GameObject MONSTEROBJECT
    {
        get { return _monster; }
    }
    public MonsterBase MONSTERBASE
    {
        get { return _monsterBase; }
    }
    public int MONSTERLEVEL
    {
        get { return _monsterLevel; }
    }

    public void MonsterInit()
    {
        _monsterBase = _monster.GetComponent<MonsterBase>();
        _monsterBase.MonsterStatusSetting(_monsterLevel, _monsterJob);
    }
}
