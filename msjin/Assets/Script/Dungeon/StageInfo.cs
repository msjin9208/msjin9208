using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
    
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

    }

     private void MonsterSetting()
    {
        Addressables.LoadAssetAsync<GameObject>("Assets/Prefab/Unit/Orc.prefab").Completed += 
            (AsyncOperationHandle<GameObject> obj)=>
            {
                var monster = obj.Result.GetComponent<UnitBase>();
                monster.InitUnit();
                _stageMonsterInfo.Add(monster);
            };
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            var player = GameManager.Instance.PLAYER.GetComponent<PlayerEquipment>();
            if(player.WEAPON.sprite == null)
            {
                UIAnimation.Instance.FailUI("무기를 착용해주세요");
                return;
            }

            Debug.Log("스테이지 넘버 : " + _stageNumber.ToString());
            if(_stageOpen == true)
            {
                MonsterSetting();
                BattleManager.Instance.StageBattleSetting(_stageMonsterInfo);

                Addressables.LoadAssetAsync<SceneBase>("Assets/Scenes/InDungeon.unity").Completed +=
                    (AsyncOperationHandle<SceneBase> scene) =>
                    {
                        var scenes = scene.Result;
                        scenes.EnterScene();
                    };
            }
        }

    }

}
