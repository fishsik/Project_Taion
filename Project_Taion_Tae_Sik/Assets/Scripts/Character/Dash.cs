using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    protected float dashGauge;            //대쉬 게이지
    public float dashGaugeMax;          //대쉬 게이지 최대
    public float dashGaugeMin;          //대쉬 게이지 최소
    public float gaugeRechargeSpeed;    //게이지 충전 속도
    public float gaugeConsumeSpeed;     //게이지 소모 속도
    public float ratio;
    protected bool isDash;                //Dash 중인가?
    protected Movement movement;

    protected void BoostOn()
    {
        isDash = true;
        movement.SetSpeed(movement.Speed() * ratio);
    }

    protected void Boosting()
    {
        if(dashGauge > 0)
        {
            Consume(ref dashGauge, dashGaugeMax, dashGaugeMin, gaugeConsumeSpeed);
        }
        else
        {
            BoostOff();
        }

    }

    protected void BoostOff()
    {
        isDash = false;
        movement.SetSpeed(movement.Speed() / ratio);
    }

    protected void Recharge(ref float value, float max, float min, float ratio)
    {
        value += Time.deltaTime * ratio;
        CorrectValue(ref value, max, min);
    }

    private void Consume(ref float value, float max, float min, float ratio)
    {
        value -= Time.deltaTime * ratio;
        CorrectValue(ref value, max, min);
    }

    private void CorrectValue(ref float value, float max, float min)
    {
        if(value > max) value = max;
        if(value < min) value = min;
    }
}
