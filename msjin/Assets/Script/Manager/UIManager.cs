using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            Debug.Log("UI �ν��Ͻ� ���� �Ϸ�!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
