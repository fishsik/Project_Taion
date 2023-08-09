using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot
{
    private Vector3 destination;
    public GameObject player;

    public float startRateMin;      // cooltime과 같음
    public float startRateMax;
    public float endRateMin;
    public float endRateMax;
    
    private float endRate;
    private float startRate;
    private float attackTime;

    void Start()
    {
        aimingTime = coolTime;
        isAiming = false;
        movement = GetComponent<Movement>();

        startRate = Random.Range(startRateMin, startRateMax);
        endRate = Random.Range(endRateMin, endRateMax);
    }

    void Update()
    {
        aimingTime += Time.deltaTime;
        attackTime += Time.deltaTime;

        if(aimingTime >= coolTime && attackTime >= startRate && !isAiming)
        {
            isAiming = true;
            aimingTime = 0;
            attackTime = 0;

            startRate = Random.Range(startRateMin, startRateMax);
        }

        if(isAiming && attackTime >= endRate)
        {
            destination = player.transform.position;       //player의 위치

            Launch(destination, PowerRatio(aimingTime));


            aimingTime = 0;
            attackTime = 0;
            isAiming = false;

            endRate = Random.Range(endRateMin, endRateMax);
        }
    }
}
