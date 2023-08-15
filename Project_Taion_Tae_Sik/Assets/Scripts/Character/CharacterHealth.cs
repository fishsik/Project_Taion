using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : Stats
{
    protected float HpGauge;

    protected void RecoverHp()
    {
        HpGauge += Time.deltaTime * HpRecoverSpeed;

        if(HpGauge > HpGaugeMax)
        {
            HpGauge = HpGaugeMax;
        }
    }

    public void Damage(float damage)
    {
        HpGauge -= damage;
    }


}
