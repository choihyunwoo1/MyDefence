using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variable
        //공격범위
        public float attackRange = 5f;

        //회전하는 주체
        public Transform partToRotate;

        //공격 타겟 - 가장 가까운 적
        private GameObject target;

        //회전 속도
        public float rotateSpeed = 7f;

        //찾기 타이머
        public float searchTimer = 0.2f;
        private float countdown = 0;
        #endregion

        #region Event Method
        private void Start()
        {
            //초기화
            countdown = searchTimer;
        }
        #endregion

        #region Gizmo
        // Scene에서만 호출되는 함수
        void OnDrawGizmosSelected()
        {
            // Gizmo 색상 지정
            Gizmos.color = Color.red;

            // 현재 위치 기준으로 반지름 viewRadius 원 그리기
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        #endregion

        #region Custom Method
        void Update()
        {
            //0.2초마다 가장 가까운 적 찾기
            if (countdown <= 0f)
            {
                //타이머 기능 - 가장 가까운 적 찾기
                UpdateTarget();
                //타이머 초기화
                countdown = searchTimer; //생성한 변수 두가지
            }
            countdown -= Time.deltaTime;

            //조건문이 참일경우 return 아래의 코드들은 실행하지 않는다
            if (target == null) return;

            // [1️] 타겟 방향 구하기
            Vector3 dir = target.transform.position - partToRotate.position;

            // [2️] 회전해야 할 방향(Quaternion) 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            // [3️] 천천히 회전 (보간)
            Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;

            // Y축으로만 회전하기
            partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
        }
        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        void UpdateTarget()
        {
            //맵 위에 있는 모든 enemy 게임 오브젝트 가져오기
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            //최소거리 변수 초기화 
            float minDistance = float.MaxValue;

            //최소거리에 있는 게임오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                //enemy과의 거리 구하기
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                { 
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            //가장 가까운 적을 찾을시, 최소거리는 공격 범위보다 작아야한다
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            { 
                target = null;
            }
        }
        #endregion
    }
}