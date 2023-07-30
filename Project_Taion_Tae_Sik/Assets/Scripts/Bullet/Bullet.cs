using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    //private Rigidbody rigidbody;
    //private PlayerShoot playerShoot;
    public float maxSpeed;      //화살의 최대 속도
    //private Vector3 destination;
    //private float powerRatio;
    private Vector3 arrowVelocity;

    void Start()
    {
        // rigidbody = GetComponent<Rigidbody>();
        // playerShoot = GetComponentInParent<PlayerShoot>();

        // arrowVelocity = playerShoot.destination - gameObject.transform.position;        //방향 설정
        // arrowVelocity = arrowVelocity * maxSpeed * playerShoot.powerRatio / arrowVelocity.magnitude;        //속도 설정
        // rigidbody.velocity = arrowVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
