using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 일정 시간 간격으로 파티클 이펙트를 플레이 시켜주는 클래스
    /// </summary>
    public class IntervalParticleSystem : MonoBehaviour
    {
        #region Variables
        //연출 파티클
        public ParticleSystem particleToPlay;

        //플레이 타이머
        [SerializeField]
        private float playTimer = 5f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method
        void Start()
        {
            // 시작 시점에 타이머 초기화
            countdown = playTimer;
        }

        void Update()
        {
            // 타이머 감소
            countdown -= Time.deltaTime;

            // 0초 이하가 되면 파티클 재생
            if (countdown <= 0f)
            {
                // 파티클이 지정되어 있다면 재생
                if (particleToPlay != null)
                {
                    particleToPlay.Play();
                }

                // 타이머 다시 초기화
                countdown = playTimer;
            }
        }

        #endregion



    }
}