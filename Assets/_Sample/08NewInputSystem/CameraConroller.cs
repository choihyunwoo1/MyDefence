using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    /// <summary>
    /// 카메라 제어: New Input 시스템
    /// </summary>
    public class CameraConroller : MonoBehaviour
    {
        #region Variables
        //new inputsystem class 객체
        private InputActionTest inputActions;

        //카메라 이동속도
        public float moveSpeed = 10f;
        #endregion

        #region Unity Event Test
        private void Awake()
        {
            //참조
            //new inputsystem class 객체 생성
            inputActions = new InputActionTest();
        }

        private void OnEnable()
        {
            //new inputsystem class 객체 활성화
            inputActions.Enable();
        }

        private void OnDisable()
        {
            //new inputsystem class 객체 비활성화
            inputActions.Disable();
        }

        private void Update()
        {
            //WASD(Arrow) 입력값에 따른 카메라 이동
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            //inputVector.x : a, d 입력값 - 호리젠탈
            //inputVector.y : w, s 입력값 - 버티칼
            //이동 : 방향 * Time.Deltatime * moveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y); //방향 구하기
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //마우스 처리




            //스페이스바 입력 값에 따른 점프 버튼 처리
            /*bool isJump = inputActions.Camera.Jump.ReadValue<bool>();
            if (isJump)
            {
                Debug.Log("jump 버튼을 눌렀습니다.");
            }*/

        }
        #endregion
    }
}
/*
1.Input Actions Editor 창 셋팅하기
- Action Map 셋팅 (ex: Camera)
- Action 셋팅 (ex: Move, Jump)

2.New Input System 에서 유저 인풋값 가져오기
 -1) 스크립트를 이용하여 값 가져오기 
  Input Actions 셋팅을 Class 파일로 만들어서 처리한다
  만들어진 Class의 객체를 생성해서 인풋 값 처리

 -2) SendMessage 방법
  
  
 -3) Unity Event 등록 방법


 */