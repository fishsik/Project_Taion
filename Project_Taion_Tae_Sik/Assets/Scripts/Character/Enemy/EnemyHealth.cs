using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
    
    void Start()
    {
        HpGauge = HpGaugeMax;
    }

    void Update()
    {
        RecoverHp();
        Debug.Log("체력 : " + HpGauge);

        if(HpGauge < 0)
        {
            Destroy(gameObject);
        }
    }
}