using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    public float spawnRateMin;
    public float spawnRateMax;
    public float changeOrbitProbability;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        gameObject.transform.position = new Vector3(-orbitRadius, 0, 0);     //player의 초기 위치 설정
        deg = 180;
        orbitRadius = minOrbitRadius;
        speed = initialSpeed;

        timeAfterSpawn = 0;
        spawnRate = RandomNumber(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        Revolve();

        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;

            if(RandomNumber(0, 1) < changeOrbitProbability)
            {
                if(RandomNumber(0, 1) > 0.5)
                {
                    IncreaseOrbit();
                }
                else
                {
                    DecreaseOrbit();
                }
            }

            spawnRate = RandomNumber(spawnRateMin, spawnRateMax);
        }
    }

    public float RandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }
}
//특정 시간 동안 무작위로 궤도가 상승하거나 감소한다.
