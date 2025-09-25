using UnityEngine;

namespace Sample
{
    // MonoBehaviour 클래스의 이벤트 함수 예제
    public class EventTest : MonoBehaviour
    {
        #region [실행단계]
        private void Awake()
        {
            Debug.Log("[1] Awake 실행");  //1회 실행
        }

        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnable 실행");  //활성화 할때마다 1회 실행
        }

        private void Start()
        {
            Debug.Log("[2] Start 실행");  //1회 실행
        }
        #endregion

        #region [업데이트]
        private void FixedUpdate()
        {
            Debug.Log("[3] FixedUpdate 실행");  //1초에 50번 호출 고정
        }

        private void Update()
        {
            Debug.Log("[4] Update 실행");  //매 프레임 마다 호출
        }

        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate 실행");  //Update()함수 실행 뒤에 바로 따라서 실행, 실행횟수는 update랑 동일
        }
        #endregion

        #region [파괴단계]
        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable 실행");  //활성화 할때마다 1회 실행
        }

        private void OnDestroy() //소멸자(object kill)
        {
            Debug.Log("[6] OnDestroy 실행");  //하이라키 창에서 삭제될때(kill) 1회 실행
        }
        #endregion
    }
}