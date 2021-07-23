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
            Debug.Log("UI 인스턴스 생성 완료!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
