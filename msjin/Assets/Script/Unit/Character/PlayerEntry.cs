using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntry : MonoBehaviour
{
    [SerializeField] GameObject _playerEntry;
    [SerializeField] GameObject _playerEnd;
    [SerializeField] float _moveSpeed;

    Vector3 _playerEntryPosition;
    Vector3 _playerEndPosition;
    GameObject _player;
    bool _playerOut = false;
    bool _playerEnter = false;



    public bool _onLoad = false;
    

    public static PlayerEntry Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;


        Messenger.AddListener(Definition.PlayerEnter, PlayerEnter);
        Messenger.AddListener(Definition.PlayerOut, PlayerOut);
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(Definition.PlayerEnter, PlayerEnter);
        Messenger.RemoveListener(Definition.PlayerOut, PlayerOut);
    }

    private void Start()
    {
        _playerEntryPosition = _playerEntry.transform.position;
        _playerEndPosition = _playerEnd.transform.position;
        _player = GameManager.Instance.PLAYER;
        _player.transform.position = _playerEntryPosition;
    }

    public void PlayerEnter()
    {
        _player.transform.position = _playerEntryPosition;
        _player.GetComponent<PlayerBase>().PlayerAnimationManager.PlayerAnimation(ANIMATIONSTATE.bRun, true);
        StartCoroutine(PlayerEntryMove());
    }

    public void PlayerOut()
    {
        _player.transform.position = _playerEndPosition;
        _player.GetComponent<PlayerBase>().PlayerAnimationManager.PlayerAnimation(ANIMATIONSTATE.bRun, true);
        StartCoroutine(PlayerOutMove());
    }


    private IEnumerator PlayerEntryMove()
    {
        if (_playerOut == true)
            yield return new WaitUntil(() => _playerOut == false);

        _playerEnter = true;
        var rotate = _player.transform.localScale;
        rotate.x = -1;
        _player.transform.localScale = rotate;

        while (_playerEnter)
        {
            var distance = Vector3.Distance(_player.transform.position, _playerEndPosition);
            if (distance > 0)
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, _playerEndPosition, _moveSpeed * Time.deltaTime);
            else
            {
                _player.GetComponent<PlayerBase>().PlayerAnimationManager.PlayerAnimation(ANIMATIONSTATE.bRun, false);
                _playerEnter = false;
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator PlayerOutMove()
    {
        if (_playerEnter == true)
            yield return new WaitUntil(() => _playerEnter == false);

        var rotate = _player.transform.localScale;
        rotate.x = 1;
        _player.transform.localScale = rotate;
        _playerOut = true;

        while (_playerOut)
        {
            var distance = Vector3.Distance(_player.transform.position, _playerEntryPosition);
            if (distance > 0)
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, _playerEntryPosition, _moveSpeed * Time.deltaTime);
            else
            {
                _player.GetComponent<PlayerBase>().PlayerAnimationManager.PlayerAnimation(ANIMATIONSTATE.bRun, false);
                //_onLoad = true;
                Messenger.Broadcast(Definition.ResoureLoad);
                _playerOut = false;
                yield break;
            }
            yield return null;
        }
    }
}
