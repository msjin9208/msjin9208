using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonList : MonoBehaviour
{
    private List<StageInfo> _dungeonStageInfoList;
    private void Start()
    {
        _dungeonStageInfoList = new List<StageInfo>();

        var list = GetComponentsInChildren<StageInfo>();

        for(int i = 0; i < list.Length; i++)
        {
            list[i].StageInit(i);
            _dungeonStageInfoList.Add(list[i]);
        }
    }
}
