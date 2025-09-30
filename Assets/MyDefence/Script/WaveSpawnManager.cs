using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 적 스폰 및 웨이브 관리하는 클래스
    /// </summary>
    public class WaveSpawnManager : MonoBehaviour
    {
        #region Variable
        //적 프리팹 오브젝트 - 원본
        public GameObject enemyPrefab;
        // public Transform Start; == this.transform

        //스폰 (5초)타이머
        private float spawnTimer = 5f; //타이머 기준 시간
        private float countdown = 0f;  //시간 누적 변수

        //웨이브 카운트
        private int waveCount = 0;

        //UI
        public TextMeshProUGUI countdownText;
        #endregion

        #region
        void Start()
        {
            //SpawnWave();
        }
        #endregion

        private void Update()
        {
            //스폰(5초) 타이머
            countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                //타이머 기능 실행
                StartCoroutine(SpawnWave());

                //타이머 초기화
                countdown = 0f;
            }

            //UI - countdownText
            //countdown 특정 범위(min, max) 설정( -값이 되지 않도록 설정)
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            //countdownText.text = string.Format("{0:00.00}", countdown);
            countdownText.text = Mathf.Round(countdown).ToString(); //반올림하여 정수형 출력



        }

        #region custom method
        //Enemy 스폰 웨이브
        IEnumerator SpawnWave()
        { 
            waveCount++;
            Debug.Log($"웨이브 카운트: {waveCount}");

            //0.5초 지연하여 enemy스폰
            for (int i = 0; i < waveCount; i++)
            {
                EnemySpawn();
                yield return new WaitForSeconds(0.5f);
            }
        }

        //시작점 위치에 Enemy 1개 생성
        void EnemySpawn()
        {
            Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);

        }
        #endregion
    }
}