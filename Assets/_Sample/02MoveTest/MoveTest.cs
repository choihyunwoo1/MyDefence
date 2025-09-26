using UnityEngine;

namespace Sample
{
    public class MoveTest : MonoBehaviour
    {
        //이동 목표 지정을 저장하는 변수 선언 및 초기화
        private Vector3 targerPosition = new Vector3(7f, 1f, 8f);
        //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스
        public Transform target;
        //이동 속도를 저장하는 변수를 선언하고 초기화
        public float speed = 5f;  //1초에 가는 거리 / 초속

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // [1] this.gameObject.transform
            // [2] this.transform.gameObject
            // [3] this.transform.position = new Vector3(7f, 1f, 8f);
            // [4] this.transform.position = targerPosition;

            // [5]
            //Debug.Log(target.position);
            //this.transform.position = target.position;

            // Debug.Log(this.transform.position);

        }

        // Update is called once per frame
        void Update()
        {
            // 플레이어의 위치를 앞으로 이동 : Z축 값이 증가한다
            // this.transform.position 연산으로 구현 - Vector3로 연산 가능

            // this.transform.position += Vector3.forward;

            // this.transform.position.z += 1; - 접근불가,반환값 수정 불가
            // this.transform.position += new Vector3(0f, 0f, 0f);
            // ({좌,우} / {위,아래} / {앞,뒤})
            //: right,left / up,down / back,front
            // One = (1,1,1) = 단위백터 / Zero = (0,0,0)

            // 앞 방향으로 1초에 1unit 만큼씩 이동하라
            // this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
            // this.transform.position += Vector3.forward * Time.deltaTime;

            // 앞 방향으로 1초에 5unit 만큼씩 이동하라
            //this.transform.position += Vector3.forward * Time.deltaTime * speed;

            //translate
            // transform.Translate(Vector3.right);   // x축 +1만큼 이동
            // transform.Translate(Vector3.up);      // y축 +1만큼 이동
            // transform.Translate(Vector3.forward); // z축 +1만큼 이동

            // dir(방향) : 이동할 방향 지정
            // Time.DeltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
            // Speed : 이동의 빠르기 지정
            //(Vector3.forward * speed * Time.deltaTime) - 속도 X 델타타임 = 크기조절
            // dir * Time.deltaTime * speed = 연산의 결과는 Vector3

            //이동방향 구하기 : (목표지점 - 현재지점) (도착위치 - 현재위치)
            //dir.normalized : 단위백터 , 길이가 1인 백터 , 정규화된 백터
            //dir.magnitude : 백터의 길이 , 크기
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * speed * Time.deltaTime);

            // 1. 방향 벡터 구하기
            // Vector3 dir = (target.position - transform.position).normalized;
            // 2. 방향으로 이동시키기
            // transform.Translate(dir * speed * Time.deltaTime, Space.World);

            //space.self - 로컬 기준
            //space.world - 글로벌 기준

        }
    }
}
/*
N Frame : 초당 N번만큼 실행됨

this.transform.position += new Vector3(0f, 0f, 1f);
= 1프레임당 1z unit 값만큼 이동한다

Time.DeltaTime  : 한 프레임 돌아오는데 걸리는 시간 = 프레임 간격 시간(초)
프레임마다 달라지는 속도를 보정해서 → 게임이 부드럽고 일정하게 동작하도록 해줌
위치 이동, 회전, 애니메이션 속도, 물체 이동 등에 거의 항상 곱해줌


 */