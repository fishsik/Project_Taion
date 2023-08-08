using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Dash
{
    // private float dashGauge;            //대쉬 게이지
    // public float dashGaugeMax;          //대쉬 게이지 최대
    // public float dashGaugeMin;          //대쉬 게이지 최소
    // public float gaugeRechargeSpeed;    //게이지 충전 속도
    // public float gaugeConsumeSpeed;     //게이지 소모 속도
    // public float ratio;
    // private bool isDash;                //Dash 중인가?
    // private Movement movement;
    
    void Start()
    {
        dashGauge = dashGaugeMax;
        isDash = false;
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        PlayerBoost();
        //Debug.Log(dashGauge);
    }
    
}
//space 키를 누르는 동안 이동이 잠깐 증가함(50% 증가)
//space 키를 떼면 효과가 없어짐.
//대쉬 게이지가 있음.(게이지가 있을 때에만 대쉬 사용 가능)
//대쉬하는 동안 게이지가 없어짐. -> 대쉬를 안 하면, 일정시간동안 게이지가 채워진다.
//변수 : 대시 게이지


//일반적으로 게이지 충전 속도만큼 게이지가 충전된다.