using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxSpeed;      //화살의 최대 속도
    private float mapRadius;

    void Start()
    {
        mapRadius = 50 * Mathf.Sqrt(2);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.magnitude > mapRadius)
        {
            Destroy(gameObject);
        }
    }
}
