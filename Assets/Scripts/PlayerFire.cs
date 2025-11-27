using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 1. 총알 발사 기능
/// 2. 총알 발사 최적화를 위한 오브젝트 풀링
/// </summary>
public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;          //총알 공장 (프리팹)
    public Transform firePoint;               //발사 위치
    //public GameObject firePoint;            //발사 위치 (코딩 상으로 더 길어짐)

    //오브젝트 풀링 = 미리 생성해둔 오브젝트를 재사용하는 기법
    //장점: 생성과 삭제에 따른 성능 저하 감소
    //단점: 메모리 사용량 증가
    
    int poolSize = 10;                         //오브젝트 풀링에 사용할 총알 최대 갯수
    int fireIndex = 0;                         //다음에 발사할 총알 인덱스

    //1. 배열로 오브젝트 풀링 구현
    //2. 리스트로 오브젝트 풀링 구현
    //3. 큐(Queue)로 오브젝트 풀링 구현
    // 오브젝트 풀링은 큐가 가장 성능이 좋다

    //GameObject[] bulletPool;                //총알 오브젝트 풀링 배열
    public List<GameObject> bulletPool;            //총알 오브젝트 풀링 리스트
    //Queue<GameObject> bulletPool;           //총알 오브젝트 풀링 큐


    void Start()
    {
        //오브젝트 풀링 초기화
        InitObjectPooling();
    }

    //오브젝트 풀링 초기화 함수
    void InitObjectPooling()
    {
        ////1. 배열로 오브젝트 풀링 초기화
        //bulletPool = new GameObject[poolSize];
        //for (int i = 0; i < poolSize; i++)
        //{
        //    //총알 오브젝트 생성
        //    GameObject bullet = Instantiate(bulletFactory);
        //    //총알 오브젝트 비활성화
        //    bullet.SetActive(false);
        //    //배열에 저장
        //    bulletPool[i] = bullet;
        //}

        //2. 리스트로 오브젝트 풀링 초기화
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            //총알 오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트 비활성화
            bullet.SetActive(false);
            //리스트에 저장
            bulletPool.Add(bullet);
        }
    }


    void Update()
    {
        //총알 발사
        Fire();
    }

    void Fire()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            //총알 발사
            //Instanciate(bulletFactory, firePoint.position, firePotin.rotation)

            ////총알 게임 오브젝트 생성
            //GameObject bullet = Instantiate(bulletFactory);
            ////총알 오브젝트 위치 설정
            //bullet.transform.position = firePoint.position;
            ////총알 오브젝트 회전 설정
            //bullet.transform.rotation = firePoint.rotation;

            //위치와 회전을 한 번에 저장해서 총알 생성
            //GameObject bullet = Instantiate(bulletFactory, firePoint.position, firePoint.rotation);
            //GameObject bullet = Instantiate(bulletFactory, firePoint.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //1. 배열로 오브젝트 풀링 발사
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.position;
            //bulletPool[fireIndex].transform.up = firePoint.up;
            //fireIndex++;
            //if (fireIndex >= poolSize)
            //{
            //    fireIndex = 0;
            //}

            //2.리스트로 오브젝트 풀링 발사(간소화)
            bulletPool[fireIndex].SetActive(true);
            bulletPool[fireIndex].transform.position = firePoint.position;
            bulletPool[fireIndex].transform.up = firePoint.up;
            fireIndex++;
            if (fireIndex >= poolSize)
            {
                fireIndex = 0;
            }

            //2. 리스트로 오브젝트 풀링 발사 (이게 진짜 오브젝트 풀링)
            //if (bulletPool.Count > 0)
            //{
            //    //리스트에서 첫번째 오브젝트 가져오기
            //    GameObject bullet = bulletPool[0];
            //    //오브젝트 활성화 및 위치, 회전 설정
            //    bulletPool[fireIndex].SetActive(true);
            //    bulletPool[fireIndex].transform.position = firePoint.position;
            //    bulletPool[fireIndex].transform.up = firePoint.up;
            //    //오브젝트 풀에서 빼준다
            //    bulletPool.Remove(bullet);
            //}
            //else //오브젝트 풀이 비어 있는 경우
            //{
            //    GameObject bullet = Instantiate(bulletFactory);
            //    bullet.SetActive(false);
            //    //오브젝트 풀에 추가
            //    bulletPool.Add(bullet);
            //}


        }


    }
}
