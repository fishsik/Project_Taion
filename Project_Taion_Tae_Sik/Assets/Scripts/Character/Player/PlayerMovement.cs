using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{

    void Start()
    {
        gameObject.transform.position = new Vector3(OrbitRadius, 0, 0);     //player의 초기 위치 설정
        deg = 0;
        OrbitRadius = minOrbitRadius;
        speed = initialSpeed;
    }

    void Update()
    {       
        Revolve();

        if(Input.GetKeyDown(KeyCode.D))
        {
            IncreaseOrbit();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            DecreaseOrbit();
        }

    }
}