using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Sprite _onImage;
    [SerializeField] Sprite _offImage;
    private bool _stageClear;
    private bool _stageOpen;
    private int _stageNumber;

    private List<UnitBase> _stageMonsterInfo;


    // 이닛은 오픈될 때만 한다.
    public void StageInit(int stageNumber)
    {
        _stageNumber = stageNumber;

        if(_stageClear == true)
            GetComponent<Image>().sprite = _onImage;
        else
            GetComponent<Image>().sprite = _offImage;

        _stageMonsterInfo = new List<UnitBase>();
        _stageOpen = true;
    }


    private void EnterStage()
    {
        MonsterSetting();
    }
     private void MonsterSetting()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("스테이지 넘버 : " + _stageNumber.ToString());
            if(_stageOpen == true)
            {
                BattleManager.Instance.StageBattleSetting(_stageMonsterInfo);
            }
        }

    }

}
