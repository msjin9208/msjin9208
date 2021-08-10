using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEquipment : MonoBehaviour
{
    SpriteRenderer _weapon; // R_Weapon
    SpriteRenderer _shield; // L_Shield
    SpriteRenderer _helmat; // 12_Helmet2
    SpriteRenderer _body; // BodyArmor
    SpriteRenderer _rfoot; // _9R_Cloth
    SpriteRenderer _lfoot; //_4L_Cloth
    SpriteRenderer _hair; // 7_Hair

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EquipmentInit(DropItemBase item)
    {
        var renderer = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < renderer.Length; i++)
        {
            if (renderer[i].name == "BodyArmor")
                _body = renderer[i];
            else if (renderer[i].name == "R_Weapon")
                _weapon = renderer[i];
            else if (renderer[i].name == "L_Shield")
                _shield = renderer[i];
            else if (renderer[i].name == "11_Helmet1")
                _helmat = renderer[i];
            else if (renderer[i].name == "_9R_Cloth")
                _rfoot = renderer[i];
            else if (renderer[i].name == "_4L_Cloth")
                _lfoot = renderer[i];
            else if (renderer[i].name == "7_Hair")
                _hair = renderer[i];
        }

        _weapon.sprite = item.GETITEMIMAGE;
        _shield.sprite = null;
        _helmat.sprite = null;

    }




    private void OnDestroy()
    {

    }
}
