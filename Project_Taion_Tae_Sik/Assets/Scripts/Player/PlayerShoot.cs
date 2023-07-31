using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float coolTime;                  //쿨타임
    private float time;           //발사 직후 시간
    public float aimingTime;               //조준 시간
    private float speed;
    private Vector3 destination;
    public GameObject bulletPrefab;
    public float maxSpeed;
    private Vector3 arrowVelocity;
    private bool isAming;
    private Rigidbody playerRigidbody;
    
    public Transform plane;

    void Start()
    {
        time = coolTime;
        isAming = false;
        playerRigidbody = GetComponent<Rigidbody>();
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
                destination = getMousePosition();
            }
        }

        if(isAming)
        {
            aim(destination, time);           //조준 함수
        }
    }

    Vector3 getMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 destination = new Vector3(0, 0, 0);
        Camera mainCamera = Camera.main;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.transform == plane) // 교차한 오브젝트가 y=0 평면인지 확인
            {
                destination = hit.point;    //총알의 y좌표, 평면의 y좌표가 같아야됨. -> 추후 수정
            }
        }
        return destination;
    }

    void aim(Vector3 destination, float timeAfterAim)
    {
        if(Input.GetMouseButton(0))
        {
            if(time > aimingTime)
            {
                time = aimingTime;
                Debug.Log("최대 세기!");
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            speed = maxSpeed * time / aimingTime;
            arrowVelocity = velocity(bullet.transform.position, destination, speed);
            Debug.Log("원래 속력 : " + speed);

            speed += Vector3.Dot(playerRigidbody.velocity, arrowVelocity) / arrowVelocity.magnitude;        //player의 속도를 반영해서 화살 속도 계산(상대속도)
            arrowVelocity = velocity(arrowVelocity, speed);
            Debug.Log("상대속도 반영한 속력 : " + speed);
            
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
    public Vector3 velocity(Vector3 departure, Vector3 arrival, float speed)
    {
        Vector3 velocity = arrival - departure;
        velocity = velocity * speed / velocity.magnitude;

        return velocity;
    }
    public Vector3 velocity(Vector3 velocity, float speed)
    {
        velocity = velocity * speed / velocity.magnitude;
        return velocity;
    }

}
//좌클릭을 눌렀을 때부터 시간측정
//좌클릭을 때는 순간 총알 발사
//측정한 좌클릭 시간에 비례해서 화살의 속도 결정(단순한 비율로 구현)
//좌클릭을 눌렀을 때, 지점을 목적지로 설정
//좌클릭을 뗐을 때, player의 위치에서 생성됨.
//재사용 대기시간 있음.
//변수 : 발사 직후 시간(time), 쿨타임, 장전 이후 시간, 장전 시간, 속도 비율, 최대 속도
//최대 화살 속도