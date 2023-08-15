using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    
    void Start()
    {
        
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
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
            
            float powerRatio = (bulletRigidbody.velocity - playerMovement.Velocity()).magnitude / maxSpeed;
            float strength = strengthMax * powerRatio;

            playerHealth.Damage(strength);
            Destroy(gameObject);
            Debug.Log("충돌!!!");
            //상대 속도 계산
            //계산한 속도 바탕으로 상대방 Hp 감소 시킴.
        }
    }
}
