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

    protected void PlayerBoost()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDash = true;
            movement.SetSpeed(movement.Speed() * ratio);
        }

        if(isDash)
        {
            if(Input.GetKeyUp(KeyCode.Space) || dashGauge <= 0)
            {
                movement.SetSpeed(movement.Speed() / ratio);
                isDash = false;
            }
            else
            {
                Consume(ref dashGauge, dashGaugeMax, dashGaugeMin, gaugeConsumeSpeed);
            }
        }

        else
        {
            Recharge(ref dashGauge, dashGaugeMax, dashGaugeMin, gaugeRechargeSpeed);
        }
    }

    protected void Boost()
    {
        isDash = true;
        movement.SetSpeed(movement.Speed() * ratio);
    }

    protected void Boosting()
    {
        //
    }

    protected void BoostOff()
    {
        //
    }

    void Recharge(ref float value, float max, float min, float ratio)
    {
        value += Time.deltaTime * ratio;
        correctValue(ref value, max, min);
    }

    void Consume(ref float value, float max, float min, float ratio)
    {
        value -= Time.deltaTime * ratio;
        correctValue(ref value, max, min);
    }

    void correctValue(ref float value, float max, float min)
    {
        if(value > max) value = max;
        if(value < min) value = min;
    }
}
