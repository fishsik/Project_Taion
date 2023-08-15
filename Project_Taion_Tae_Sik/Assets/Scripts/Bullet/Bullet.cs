using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxSpeed;      //화살의 최대 속도
    public float minSpeed;
    protected const float mapRadius = 70;
    public float strengthMax;      //총알의 공격력

    protected void DestructBullet()
    {
        if(gameObject.transform.position.magnitude > mapRadius)
        {
            Destroy(gameObject);
        }
    }
}