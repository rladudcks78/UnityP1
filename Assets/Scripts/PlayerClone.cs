using UnityEngine;

/// <summary>
///  1. 아이템 먹어서 보조비행기가 새롭게 생성되는 기능 (On/Off)
///  2. 보조비행기는 일정시간마다 자동으로 총알 발사 한다.
/// </summary>
public class PlayerClone : MonoBehaviour
{
    public GameObject clone;                //보조비행기 오브젝트
    public GameObject bulletFactory;        //총알 공장
    public float fireTime = 1f;             //총알 발사 간격 (1초에 한 번씩)
    float timer = 0f;                       //시간 누적 변수

    // Update is called once per frame
    void Update()
    {
        //아이템 먹었을 때 보조비행기 생성
        CreateClone();
        AutoFire();
    }

    void CreateClone()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //clone.SetActive(true);
            clone.SetActive(!clone.activeSelf); //토글 형식

            //bool isJump = !isJump; (불변수로 토글키 만드는 형식)
        }
    }

    void AutoFire()
    {
        if (clone.activeSelf)
        {
            // 중요함
            // 몇초에 한번씩 이벤트 발생
            // timer 변수를 이용해서 시간 누적
            // 게임에서 정말 자주 사용함

            // 시간 누적
            timer += Time.deltaTime;
            if (timer >= fireTime)
            {
                timer = 0f;

                //총알 발사
                //GameObject[] bullet = new GameObject[2];
                GameObject[] bullet = new GameObject[clone.transform.childCount];
                for (int i = 0; i < clone.transform.childCount; i++)
                {
                    bullet[i] = Instantiate(bulletFactory);
                    bullet[i].transform.position = clone.transform.GetChild(i).position;
                }
            }
        }
    }
}

