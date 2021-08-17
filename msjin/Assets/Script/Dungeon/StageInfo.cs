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
    private InDungeon _indungeon;

    private List<GameObject> _stageMonsterInfo;

    
    // �̴��� ���µ� ���� �Ѵ�.
    public void StageInit(int stageNumber)
    {
        _stageNumber = stageNumber;

        if(_stageClear == true)
            GetComponent<Image>().sprite = _onImage;
        else
            GetComponent<Image>().sprite = _offImage;

        _stageMonsterInfo = new List<GameObject>();
        _stageOpen = true;
    }

     private void MonsterSetting()
    {

        var monsters = BattleManager.Instance.MONSTERDIC;
        var etor = monsters.GetEnumerator();

        while(etor.MoveNext())
        {
            var monster = etor.Current.Value;
            if(monster.MONSTERLEVEL == _stageNumber + 1)
            {
                _stageMonsterInfo.Add(monster.MONSTEROBJECT);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            var player = GameManager.Instance.PLAYER.GetComponent<PlayerEquipment>();
            if(player.WEAPON.sprite == null)
            {
                UIAnimation.Instance.FailUI("���⸦ �������ּ���");
                return;
            }

            Debug.Log("�������� �ѹ� : " + _stageNumber.ToString());
            if(_stageOpen == true)
            {
                MonsterSetting();
                BattleManager.Instance.StageBattleSetting(_stageMonsterInfo);

                _indungeon = new InDungeon();
                SceneMgr.Instance.ChangeNextScene(_indungeon);
            }
        }
    }

}
