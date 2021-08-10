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
    MonsterBase _monsterBase;
    [SerializeField] float _attack;
    [SerializeField] float _attackSpeed;
    [SerializeField] float _defence;
    [SerializeField] float _hp;
    [SerializeField] float _mp;
    [SerializeField] MonsterJob _monsterJob;
    
    public GameObject MONSTEROBJECT
    {
        get { return _monster; }
    }
    public MonsterBase MONSTERBASE
    {
        get { return _monsterBase; }
    }

    public void MonsterInit()
    {
        _monsterBase = _monster.GetComponent<MonsterBase>();
        _monsterBase.MonsterStatusSetting(_attack, _attackSpeed, _defence, _hp, _mp, _monsterJob);
    }
}
