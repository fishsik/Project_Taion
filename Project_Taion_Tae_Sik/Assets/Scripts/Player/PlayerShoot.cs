using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float coolTime;                  //쿨타임
    private float time;           //발사 직후 시간
    public float aimingTime;               //조준 시간
    private float powerRatio;
    private Vector3 destination;
    public GameObject bulletPrefab;
    public float maxSpeed;
    private Vector3 arrowVelocity;
    private bool isAming;

    private Vector3 mousePosition;
    private Camera mainCamera;
    private Ray ray;
    public Transform plane;

    void Start()
    {
        time = coolTime;
        isAming = false;

        mainCamera = Camera.main;
    }

    void Update()
    {
        time += Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            if(time >= coolTime)
            {
                isAming = true;
                time = 0;
                //destination = getMousePosition();

                mousePosition = Input.mousePosition;
                ray = mainCamera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    if (hit.transform == plane) // 교차한 오브젝트가 y=0 평면인지 확인
                    {
                        destination = hit.point;
                    }
                }
            }
        }

        if(isAming)
        {
            aim(destination, time);           //조준 함수
        }
    }

    // Vector3 getMousePosition()
    // {

    // }

    void aim(Vector3 destination, float timeAfterAim)
    {
        if(Input.GetMouseButton(0))
        {
            if(time > aimingTime)
            {
                time = aimingTime;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            powerRatio = time / aimingTime;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            arrowVelocity = destination - bullet.transform.position;
            arrowVelocity = arrowVelocity * maxSpeed * powerRatio / arrowVelocity.magnitude;

            shoot(bullet, arrowVelocity);
            isAming = false;
            time = 0;
        }
    }

    void shoot(GameObject bullet, Vector3 velocity)
    {
        Rigidbody arrowRigidbody = bullet.GetComponent<Rigidbody>();
        arrowRigidbody.velocity = arrowVelocity;
    }
    // public Vector3 velocity()
    // {
    //     //
    // }
}
//좌클릭을 눌렀을 때부터 시간측정
//좌클릭을 때는 순간 총알 발사
//측정한 좌클릭 시간에 비례해서 화살의 속도 결정(단순한 비율로 구현)
//좌클릭을 눌렀을 때, 지점을 목적지로 설정
//좌클릭을 뗐을 때, player의 위치에서 생성됨.
//재사용 대기시간 있음.

//변수 : 발사 직후 시간(time), 쿨타임, 장전 이후 시간, 장전 시간, 속도 비율, 최대 속도
//최대 화살 속도