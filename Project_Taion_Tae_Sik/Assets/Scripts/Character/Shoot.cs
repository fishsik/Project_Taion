using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float coolTime;                  //쿨타임
    public float aimingTimeMax;               //조준 시간
    public GameObject bulletPrefab;
    protected float aimingTime;           //발사 직후 시간
    protected bool isAiming;
    protected Movement movement;

    protected float PowerRatio(float time)
    {
        if(time > aimingTimeMax)
        {
            time = aimingTimeMax;
        }

        return time / aimingTimeMax;
    }

    protected void Launch(Vector3 destination, float PowerRatio)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet arrow = bullet.GetComponent<Bullet>();

        Vector3 arrowVelocity = Velocity(bullet.transform.position, destination, 1f);       //속도(방향만) 생성
            
            
            
        float speed = arrow.maxSpeed + (PowerRatio - 1) * (arrow.maxSpeed - arrow.minSpeed) + Vector3.Dot(movement.Velocity(), arrowVelocity);
            //Debug.Log("속력" + speed);
        arrowVelocity = Velocity(arrowVelocity, speed);


        Rigidbody arrowRigidbody = bullet.GetComponent<Rigidbody>();
        arrowRigidbody.velocity = arrowVelocity;
    }

    public Vector3 Velocity(Vector3 departure, Vector3 arrival, float speed)
    {
        Vector3 velocity = arrival - departure;
        velocity = velocity * speed / velocity.magnitude;

        return velocity;
    }
    public Vector3 Velocity(Vector3 velocity, float speed)
    {
        velocity = velocity / velocity.magnitude;       //단위벡터로 변형
        velocity = speed * velocity;
        return velocity;
    }
}
