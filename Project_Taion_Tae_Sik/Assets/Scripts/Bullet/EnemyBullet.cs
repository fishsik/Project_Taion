using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
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
        if(other.tag == "Player")
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerHealth = other.GetComponent<PlayerHealth>();
            
            powerRatio = (bulletRigidbody.velocity - playerMovement.Velocity()).magnitude / maxSpeed;
            strength = strengthMax * powerRatio;

            playerHealth.Damage(strength);
            Destroy(gameObject);
            Debug.Log("충돌!!!");
            //상대 속도 계산
            //계산한 속도 바탕으로 상대방 Hp 감소 시킴.
        }
    }
}
