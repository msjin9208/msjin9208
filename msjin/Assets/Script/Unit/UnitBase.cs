using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UnitBase : MonoBehaviour
{
    public struct UnitStatus
    {
       public float _hp { get; set; }
        public float _mp { get; set; }
        public float _attack { get; set; }
        public float _defence { get; set; }
        public float _attackSpeed { get; set; }
    }

    protected UnitStatus _unitStatus;

    public UnitStatus UNITSTATUS
    {
        get { return _unitStatus; }
    }
    

    public virtual void InitUnit()
    {
        _unitStatus = new UnitStatus();
    }

    
}
