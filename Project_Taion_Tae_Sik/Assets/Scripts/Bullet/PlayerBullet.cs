using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private EnemyMovement enemyMovement;
    private EnemyHealth enemyHealth;
    private Rigidbody bulletRigidbody;
            
    private float powerRatio;
    private float strength;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DestructBullet();
    }

    protected void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyMovement = other.GetComponent<EnemyMovement>();
            enemyHealth = other.GetComponent<EnemyHealth>();
            
            powerRatio = (bulletRigidbody.velocity - enemyMovement.Velocity()).magnitude / maxSpeed;
            strength = strengthMax * powerRatio;

            enemyHealth.Damage(strength);
            Destroy(gameObject);
            Debug.Log("충돌!!!");
            //상대 속도 계산
            //계산한 속도 바탕으로 상대방 Hp 감소 시킴.
        }
    }
}
