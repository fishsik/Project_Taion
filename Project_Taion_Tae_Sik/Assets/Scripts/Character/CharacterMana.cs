using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMana : Stats
{
    // Start is called before the first frame update
    protected float MpGauge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void RecoverMp()
    {
        MpGauge += Time.deltaTime * MpRecoverSpeed;

        if(MpGauge > MpGaugeMax)
        {
            MpGauge = MpGaugeMax;
        }
    }
}
