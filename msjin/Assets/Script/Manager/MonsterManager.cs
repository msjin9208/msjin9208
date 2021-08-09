using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;

    [SerializeField] GameObject _orc;
    
    private List<GameObject> _monsterList;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {



        _monsterList.Add(_orc);
        DontDestroyOnLoad(gameObject);
    }

}
