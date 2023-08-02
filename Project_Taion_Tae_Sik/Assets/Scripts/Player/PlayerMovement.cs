using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;  //플레이어 속도
    public float initialPlayerSpeed;    //플레이어 초기 속도
    public float changeOrbitRadius;  //궤도 변경 반지름
    public float initialOrbitRadius;   //초기 궤도 반지름(최소)
    private float OrbitRadius;    //현재 궤도 반지름
    private float deg;       //각도

    void Start()
    {
        deg = 0;
        OrbitRadius = initialOrbitRadius;
        playerSpeed = initialPlayerSpeed;
        gameObject.transform.position = new Vector3(OrbitRadius, 0, 0);     //player의 초기 위치 설정
    }

    void Update()
    {
        float z;
        float x;

        changeOrbit();

        deg += Time.deltaTime * initialOrbitRadius * playerSpeed / OrbitRadius;
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

    void changeOrbit()
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
    }

    public Vector3 velocity()
    {
        float velocityX = -Mathf.Sin(Mathf.Deg2Rad * deg);
        float velocityY = Mathf.Cos(Mathf.Deg2Rad * deg);
        
        return playerSpeed * new Vector3(velocityX, velocityY);
    }
}