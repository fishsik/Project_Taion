using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Shoot
{
    private Vector3 destination;   
    public Transform plane;

    void Start()
    {
        aimingTime = coolTime;
        isAiming = false;
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        aimingTime += Time.deltaTime;

        if(aimingTime >= coolTime && Input.GetMouseButtonDown(0))
        {
            isAiming = true;
            aimingTime = 0;
        }

        if(isAiming && Input.GetMouseButtonUp(0))
        {
            destination = GetMousePosition();

            Launch(destination, PowerRatio(aimingTime));


            aimingTime = 0;
            isAiming = false;
        }
    }

    Vector3 GetMousePosition()
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
}
//좌클릭을 눌렀을 때부터 시간측정
//좌클릭을 때는 순간 총알 발사
//측정한 좌클릭 시간에 비례해서 화살의 속도 결정(단순한 비율로 구현)
//좌클릭을 눌렀을 때, 지점을 목적지로 설정
//좌클릭을 뗐을 때, player의 위치에서 생성됨.
//재사용 대기시간 있음.
//변수 : 발사 직후 시간(time), 쿨타임, 장전 이후 시간, 장전 시간, 속도 비율, 최대 속도
//최대 화살 속도