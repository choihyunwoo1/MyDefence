using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 랜덤 애니메이션 플레이
    /// </summary>
    public class TorchFlameAnimation : MonoBehaviour
    {
        #region Variables
        //참조
        private Animator animator;

        public float minInterval = 2f;
        public float maxInterval = 5f;

        private float timer;
        private int lastFlame = -1;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            animator = GetComponent<Animator>(); //애니메이터 컴포넌트 객체 가져오기

            // 처음 시작 시 타이머를 랜덤값으로 설정
            timer = Random.Range(minInterval, maxInterval);
        }
        void Update()
        {

            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                PlayRandomFlame();
                timer = Random.Range(minInterval, maxInterval);
            }
        }
        #endregion

        #region Custom Method
        void PlayRandomFlame()
        {
            // 현재 상태를 기준으로 다른 Flame 값만 선택
            int currentFlame = animator.GetInteger("Flame");
            int randomFlame;

            do
            {
                randomFlame = Random.Range(1, 4); // 1~3 사이 정수
            } while (randomFlame == currentFlame); // 같은 번호는 피함

            animator.SetInteger("Flame", randomFlame);
            Debug.Log($"🔥 Flame 값 변경: {currentFlame} → {randomFlame}");
        }
        #endregion
    }
}