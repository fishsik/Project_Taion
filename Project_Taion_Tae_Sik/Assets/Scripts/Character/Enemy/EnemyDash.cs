using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : Dash
{
    public float startRateMin;
    public float startRateMax;
    public float endRateMin;
    public float endRateMax;
    
    private float endRate;
    private float startRate;
    private float time;

    void Start()
    {
        dashGauge = dashGaugeMax;
        isDash = false;
        movement = GetComponent<Movement>();

        time = 0;
        startRate = Random.Range(startRateMin, startRateMax);
        endRate = Random.Range(endRateMin, endRateMax);
    }

    void Update()
    {
        time += Time.deltaTime;
        
        if(time >= startRate && !isDash)
        {
            time = 0;
            
            BoostOn();

            startRate = Random.Range(startRateMin, startRateMax);
        }

        if(isDash)
        {
            Boosting();
        }
        else
        {
            Recharge(ref dashGauge, dashGaugeMax, dashGaugeMin, gaugeRechargeSpeed);
        }

        if(time >= endRate && isDash)
        {
            time = 0;

            BoostOff();

            endRate = Random.Range(endRateMin, endRateMax);
        }
    }
}