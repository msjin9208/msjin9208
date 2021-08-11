using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEntry : MonoBehaviour
{
    [SerializeField] GameObject _monsterEntry;
    [SerializeField] GameObject _monsterEnd;
    [SerializeField] float _moveSpeed;

    private void Awake()
    {
        Messenger.AddListener<GameObject>(Definition.MonsterEntry, MonsterEnter);

        DontDestroyOnLoad(gameObject);
    }


    private void MonsterEnter(GameObject monster)
    {
        if (monster == null)
            return;

        
        monster.SetActive(true);
        StartCoroutine(MonsterMove(monster));
    }
    private IEnumerator MonsterMove(GameObject monster)
    {
        monster.transform.position = _monsterEntry.transform.position;
        bool move = true;
        while(move)
        {
            var distance = Vector3.Distance(monster.transform.position, _monsterEnd.transform.position);
            if(distance > 0)
                monster.transform.position = Vector3.MoveTowards(monster.transform.position, _monsterEnd.transform.position, _moveSpeed * Time.deltaTime);
            else
            {
                move = false;
                yield break;
            }
            yield return null;
        }

    }

    private void OnDestroy()
    {
        Messenger.RemoveListener<GameObject>(Definition.MonsterEntry, MonsterEnter);
    }
}
