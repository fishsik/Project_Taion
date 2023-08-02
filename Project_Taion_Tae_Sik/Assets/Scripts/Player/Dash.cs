using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private float dashGauge;            //대쉬 게이지
    public float gaugeRechargeSpeed;    //게이지 충전 속도
    public float gaugeConsumeSpeed;     //게이지 소모 속도
    public float ratio;
    private bool isDash;                //Dash 중인가?
    private PlayerMovement playerMovement;
    
    void Start()
    {
        dashGauge = 100;
        isDash = false;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Recharge();
        
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashGauge > 0)
            {
                isDash = true;
                playerMovement.playerSpeed *= ratio;
            }
        }

        if(isDash)
        {
            if(dashGauge > 0)
            {
                Consume();
            }

            else
            {
                isDash = false;
                playerMovement.playerSpeed /= ratio;
                dashGauge = 0;
            }

            if(Input.GetKeyUp(KeyCode.Space))
            {
                playerMovement.playerSpeed /= ratio;
                isDash = false;
            }
        }
    }

    void Recharge()
    {
        dashGauge += Time.deltaTime * gaugeRechargeSpeed;
        
        if(dashGauge > 100)
        {
            dashGauge = 100;
        }
    }

    void Consume()
    {
        dashGauge -= Time.deltaTime * gaugeConsumeSpeed;
    }
}
//space 키를 누르는 동안 이동이 잠깐 증가함(50% 증가)
//space 키를 떼면 효과가 없어짐.
//대쉬 게이지가 있음.(게이지가 있을 때에만 대쉬 사용 가능)
//대쉬하는 동안 게이지가 없어짐. -> 대쉬를 안 하면, 일정시간동안 게이지가 채워진다.
//변수 : 대시 게이지


//일반적으로 게이지 충전 속도만큼 게이지가 충전된다.