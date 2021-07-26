using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMgr : MonoBehaviour
{
    public static SceneMgr Instance;

    private Stack<SceneBase> _stackScene;
    private SceneBase _currentScene;
    private SceneBase _nextScene;

    public bool _readyToLoad = false;
    public bool _sceneLoad = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Debug.Log("씬 매니저 인스턴스 생성 완료!");
        }
        if(_stackScene == null)
            _stackScene = new Stack<SceneBase>();

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _nextScene = null;
        _currentScene = new GameStart();
        _stackScene.Push(_currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if(_readyToLoad == true)
        {
            LoadScene();
            _readyToLoad = false;  
        }
    }

    public void ChangeNextScene(SceneBase scene)
    {
        if(_nextScene == null)
            _nextScene = scene;

        _currentScene.ExitScene();
        _stackScene.Push(_nextScene);
        _currentScene = _stackScene.Peek();

        _nextScene = null;
    }

    public void ChangePreviewScene()
    {
        if(_stackScene.Count <= 1)
        {
            Debug.Log("더이상 뒤로 갈 수 있는 씬이 없습니다.!");
            return;
        }    

        _currentScene.ExitScene();
        _stackScene.Pop();

        _currentScene = _stackScene.Peek();
    }

    public void LoadScene()
    {
        _currentScene.EnterScene();
        SceneManager.LoadScene(_currentScene.Scene().ToString());
        
        _currentScene.ResourceLoad();
    }


   
}
