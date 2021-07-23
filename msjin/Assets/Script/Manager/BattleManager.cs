using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    static public BattleManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
