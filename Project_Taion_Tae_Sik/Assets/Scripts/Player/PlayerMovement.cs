using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float initialOrbitRadius;   //초기 궤도 반지름
    private float OrbitRadius;    //현재 궤도 반지름
    private float deg;       //각도
    public float initialAngularVelocity;  //플레이어 초기 각속도
    public float changeOrbitRadius;  //궤도 변경 반지름

    void Start()
    {
        deg = 0;
        OrbitRadius = initialOrbitRadius;
        gameObject.transform.position = new Vector3(OrbitRadius, 3, 0);     //player의 초기 위치 설정
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(OrbitRadius >= initialOrbitRadius && OrbitRadius < initialOrbitRadius + 5 * changeOrbitRadius)
            {
                OrbitRadius += changeOrbitRadius;
            }
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(OrbitRadius > initialOrbitRadius && OrbitRadius <= initialOrbitRadius + 5 * changeOrbitRadius)
            {
                OrbitRadius -= changeOrbitRadius;
            }
        }

        deg += Time.deltaTime * initialOrbitRadius * initialAngularVelocity / OrbitRadius;
        if(deg < 360)
        {
            var rad = Mathf.Deg2Rad * deg;
            var z = OrbitRadius * Mathf.Sin(rad);
            var x = OrbitRadius * Mathf.Cos(rad);
            gameObject.transform.position = new Vector3(x, 0, z);
            gameObject.transform.rotation = Quaternion.Euler(0, deg * -1, 0);
        }
        else
        {
            deg = 0;
        }        
    }
}
