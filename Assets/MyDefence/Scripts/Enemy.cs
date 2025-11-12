using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// Enemy의 체력을 관리하는 클래스
    /// </summary>
    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        //이동 목표 위치를 가지고 있는 오브젝트
        private Transform target;

        //이동 속도
        [SerializeField]
        private float speed = 10f;

        //이동속도 초기화
        [SerializeField]
        private float startSpeed = 4f;

        //이동 웨이포인트 인덱스
        int wayPointIndex;

        //체력
        private float health;

        [SerializeField]
        private float startHealth = 100f;    //체력 초기값

        //죽음 체크
        private bool isDeath = false;

        //죽음 효과
        public GameObject deathEffectPrefab;

        //죽음 보상
        [SerializeField]
        private int rewardMoney = 50;

        //UI
        public Image hpBarImage;
        #endregion


        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            health = startHealth;
            speed = startSpeed;
            wayPointIndex = 0;

            //이동 목표지점 0번에서 설정
            target = WayPoints.points[wayPointIndex];
        }

        // Update is called once per frame
        void Update()
        {
            //타겟을 향해 이동
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착 판정
            //타겟과 Eenmy와 거리를 구해서 일정거리안에 들어오면 도착이라고 판정한다
            float distance =  Vector3.Distance(target.position, this.transform.position);
            if(distance <= 0.1f)
            {
                SetNextTarget();
            }

            //이동속도 초기 속도로 복원
            speed = startSpeed;
        }
        #endregion

        #region Custom Method
        //다음 타겟 설정
        void SetNextTarget()
        {
            // 만약 마지막 웨이포인트까지 다 돌았다면
            if (wayPointIndex == WayPoints.points.Length-1)
            {
                Arrive(); // 종점 도착 처리
                return;   // 아래 코드 실행 안 함
            }

            // 다음 웨이포인트 설정
            //Debug.Log("다음 타겟 설정: wayPointIndex++");
            wayPointIndex++;
            target = WayPoints.points[wayPointIndex];
        }

        //종점 도착
        private void Arrive()
        {
            //생명 사용
            PlayerStats.UseLives(1);

            //살아 있는 적의 수를 줄인다
            WaveSpawnManager.enemyAlive--;

            //Enemy 킬
            Destroy(this.gameObject);
        }

        //매개변수로 들어온 만큼 데미지를 입는다
        public void TakeDamage(float damage)
        {
            health -= damage;
            //Debug.Log($"Enemy Health: {health}");

            //UI
            hpBarImage.fillAmount = health / startHealth;

            //죽음 체크
            if (health <= 0 && isDeath == false)
            {
                health = 0;
                Die();
            }
        }

        //죽음 처리
        private void Die()
        {
            //죽음 체크
            isDeath = true;

            //죽음 처리...
            //effct 효과 (vfx, sfx)
            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //살아 있는 적의 수를 줄인다
            WaveSpawnManager.enemyAlive--;

            //보상 처리(골드, 경험치, 아이템..)
            PlayerStats.AddMoney(rewardMoney);

            //Enemy Kill
            Destroy(this.gameObject);
        }

        //이동속도 느리게 하기
        public void Slow(float rate)    //40%
        {
            speed = startSpeed * (1 - rate);       //4 * (1 - 0.4) = 2.4
        }
        #endregion
    }
}