using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public GameObject bulletFactory;          //총알 공장 (프리팹)
    public Transform firePoint;
    int poolSize = 10;                         //오브젝트 풀링에 사용할 총알 최대 갯수
    int fireIndex = 0;

    public List<GameObject> bulletPool;

    public float attackRate = 1.0f;
    public float attackRange = 2.0f;
    public Transform target;
    private float timeSinceLastAttack = 0.0f;

    void Awake()
    {
        // bulletPool = new List<GameObject>();
        // 총알 리스트를 초기화합니다.
        bulletPool = new List<GameObject>();

        // for (int i = 0; i < poolSize; i++)
        // [for문 시작] poolSize(10개)만큼 반복합니다. [무슨 뜻인지] 총알을 poolSize 개수만큼 미리 만드는 반복문입니다.
        // [왜 사용하였는지] 오브젝트 풀링을 위해 총알 프리팹을 복사하여 메모리에 로드하기 위해 사용합니다.
        for (int i = 0; i < poolSize; i++)
        {
            // GameObject bullet = Instantiate(bulletFactory);
            // 총알 공장(bulletFactory) 프리팹을 복제(Instantiate)하여 새로운 총알 오브젝트를 만듭니다.
            GameObject bullet = Instantiate(bulletFactory);

            // bullet.SetActive(false);
            // 생성된 총알을 일단 비활성화(SetActive(false))하여 대기 상태로 만듭니다.
            bullet.SetActive(false);

            // bulletPool.Add(bullet);
            // 생성된 총알 오브젝트를 리스트에 추가하여 관리합니다.
            bulletPool.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        timeSinceLastAttack += Time.deltaTime;
        float attackInterval = 1.0f / attackRate;

        if (target != null && timeSinceLastAttack >= attackInterval)
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget <= attackRange)
            {
                Fire();
                timeSinceLastAttack = 0.0f;
            }
        }
    }

    void Fire()
    {
        bulletPool[fireIndex].SetActive(true);
        bulletPool[fireIndex].transform.position = firePoint.position;
        bulletPool[fireIndex].transform.up = firePoint.up;
        fireIndex++;
        if (fireIndex >= poolSize)
        {
            fireIndex = 0;
        }
    }
}
