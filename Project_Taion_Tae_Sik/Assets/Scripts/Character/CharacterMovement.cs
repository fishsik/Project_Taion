using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : Movement
{
    //public float initialSpeed;    //플레이어 초기 속도
    public float changeOrbitRadius;  //궤도 변경 반지름
    //public float minOrbitRadius;   //초기 궤도 반지름(최소)///////
    protected float maxOrbitRadius; //최대 궤도 반지름
    
    //protected float OrbitRadius;    //현재 궤도 반지름///////
    //protected float deg;       //각도///////

    /*void Start()
    {
        //...
    }c

    void Update()
    {
        //...
    }*/

    protected void IncreaseOrbit()
    {
        if(orbitRadius >= minOrbitRadius && orbitRadius < minOrbitRadius + 5 * changeOrbitRadius)
        {
            orbitRadius += changeOrbitRadius;
        }
    }

    protected void DecreaseOrbit()
    {
        if(orbitRadius > minOrbitRadius && orbitRadius <= minOrbitRadius + 5 * changeOrbitRadius)
        {
                orbitRadius -= changeOrbitRadius;
        }
    }

    // public Vector3 velocity()
    // {
    //     float velocityX = -Mathf.Sin(Mathf.Deg2Rad * deg);
    //     float velocityY = Mathf.Cos(Mathf.Deg2Rad * deg);
        
    //     return speed * new Vector3(velocityX, velocityY);
    // }
}
