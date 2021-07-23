using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] Button _gameStart;
    [SerializeField] Button _gameQuit;

    private Lobby _lobby;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        _gameStart.onClick.AddListener(GameStart);
        _gameQuit.onClick.AddListener(GameQuit);
        _lobby = new Lobby();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GameStart()
    {
        UIAnimation.Instance.FadeOut();
        Debug.Log("다음 씬 이동");

        SceneMgr.Instance.ChangeNextScene(_lobby);
    }
    private void GameQuit()
    {
        Application.Quit();
        Debug.Log("게임 종료!");
    }


    private void OnDestroy()
    {
        _lobby = null;
    }
}
