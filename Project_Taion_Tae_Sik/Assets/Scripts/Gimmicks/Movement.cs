using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Gimmicks
{
    public float initialSpeed;    //플레이어 초기 속도
    public float minOrbitRadius;    //초기 궤도 반지름(최소)///////
    protected float speed;          //오브젝트 속력(임시로 public!!!)
    protected float orbitRadius;    //현재 궤도 반지름
    protected float deg;            //각위치

    protected void Revolve()
    {
        float z;
        float x;

        deg += Time.deltaTime * minOrbitRadius * speed / orbitRadius;
        if(deg < 360)
        {
            z = orbitRadius * Mathf.Sin(Mathf.Deg2Rad * deg);
            x = orbitRadius * Mathf.Cos(Mathf.Deg2Rad * deg);
            gameObject.transform.position = new Vector3(x, 0, z);
            gameObject.transform.rotation = Quaternion.Euler(0, deg * -1, 0);
        }
        else
        {
            deg = 0;
        }
    }

    public Vector3 Velocity()
    {
        float velocityX = -Mathf.Sin(Mathf.Deg2Rad * deg);
        float velocityY = Mathf.Cos(Mathf.Deg2Rad * deg);
        
        return speed * new Vector3(velocityX, velocityY);
    }

    public float Speed()
    {
        return speed;
    }

    public void SetSpeed(float argument)
    {
        speed = argument;
    }
}
