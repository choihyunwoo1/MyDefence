using UnityEngine;
using System.Collections;

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