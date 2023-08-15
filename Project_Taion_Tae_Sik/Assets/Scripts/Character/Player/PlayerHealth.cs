using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    // Start is called before the first frame update
    void Start()
    {
        HpGauge = HpGaugeMax;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("체력 : " + HpGauge);
    }
}
