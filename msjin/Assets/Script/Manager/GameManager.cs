using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject _playeObject;
    private UnitBase _playerBase;

    public GameObject PLAYER
    {
        get { return _playeObject; }
        set { _playeObject = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("게임 매니저 인스턴스 생성 완료");
        }


        _playeObject = GameObject.Instantiate<GameObject>(ResourceManager.Instance.Player, new Vector3(0, 0, 0), Quaternion.identity);
        _playerBase = _playeObject.GetComponent<PlayerBase>();

        _playeObject.SetActive(false);
        _playerBase.InitUnit();

        DontDestroyOnLoad(_playeObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
