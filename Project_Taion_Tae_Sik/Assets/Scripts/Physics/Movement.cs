using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Physics
{
    public float speed;  //플레이어 속도
    public float initialSpeed;    //플레이어 초기 속도
    public float changeOrbitRadius;  //궤도 변경 반지름
    public float minOrbitRadius;   //초기 궤도 반지름(최소)
    protected float maxOrbitRadius; //최대 궤도 반지름
    protected int changeNumber;     //궤도 변경 횟수
    private float OrbitRadius;    //현재 궤도 반지름
    private float deg;       //각도

    void Start()
    {
        deg = 0;
        OrbitRadius = minOrbitRadius;
        Speed = initialSpeed;
        gameObject.transform.position = new Vector3(OrbitRadius, 0, 0);     //player의 초기 위치 설정
    }

    void Update()
    {
        float z;
        float x;

        deg += Time.deltaTime * minOrbitRadius * Speed / OrbitRadius;
        if(deg < 360)
        {
            z = OrbitRadius * Mathf.Sin(Mathf.Deg2Rad * deg);
            x = OrbitRadius * Mathf.Cos(Mathf.Deg2Rad * deg);
            gameObject.transform.position = new Vector3(x, 0, z);
            gameObject.transform.rotation = Quaternion.Euler(0, deg * -1, 0);
        }
        else
        {
            deg = 0;
        }
    }

    public Vector3 velocity()
    {
        float velocityX = -Mathf.Sin(Mathf.Deg2Rad * deg);
        float velocityY = Mathf.Cos(Mathf.Deg2Rad * deg);
        
        return Speed * new Vector3(velocityX, velocityY);
    }
}
