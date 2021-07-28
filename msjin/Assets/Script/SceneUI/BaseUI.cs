using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    [SerializeField] Image _playerNickName;
    [SerializeField] Image _playerJob;
    [SerializeField] Image _playerLV;
    [SerializeField] Image _playerGold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SceneUIInit()
    {
        Messenger.AddListener(Definition.RefreshPlayerInfo, RefreshPlayerInfo);
    }

    public virtual void SceneEnter(SceneBase scene)
    {
        
        SceneMgr.Instance.ChangeNextScene(scene);
    }
    public virtual void ScenePreviewEnter()
    {
        SceneMgr.Instance.ChangePreviewScene();
    }

    //보안 생각 해야 돼 나중에 private로 변경해야할수도
    private void RefreshPlayerInfo()
    {
        var playerNickName = _playerNickName.GetComponentInChildren<Text>();
        var playerLV = _playerLV.GetComponentInChildren<Text>();
        var playerJob = _playerJob.GetComponentInChildren<Text>();
        var playerGold = _playerGold.GetComponentInChildren<Text>();

        var playerInfo = GameManager.Instance.PLAYER.GetComponent<PlayerBase>().PlayerInfo;
        playerNickName.text = string.Format("ID : " + playerInfo._info._playerNickName.ToString());
        playerLV.text = string.Format("LV : " + playerInfo._info._playerLevel.ToString());
        playerJob.text = string.Format("Job : " + playerInfo._info._playerJob.ToString());
        playerGold.text = string.Format("Gold : " + playerInfo._info._playerGold.ToString());
    }
}
