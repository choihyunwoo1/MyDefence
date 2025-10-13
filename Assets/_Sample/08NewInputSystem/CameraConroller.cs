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
        public float borderThickness = 10f; // 스크린 가장자리 감지 영역 (픽셀 단위)
        public float moveSpeed = 10f;  //카메라 이동속도
        Vector2 inputVector;//카메라 이동 입력값 저장

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
            inputActions.Camera.Jump.performed += Jump;
            //inputActions.Camera.Jump.started += Jump;
            //inputActions.Camera.Jump.cancaled += Jump;

        }

        private void OnDisable()
         {
             //new inputsystem class 객체 비활성화
             inputActions.Disable();
            inputActions.Camera.Jump.performed -= Jump;
        }

         //(Awake, OnEnable, OnDisable)은 세개 세트로 사용

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
             Vector2 mousePosition = inputActions.Camera.MousePosition.ReadValue<Vector2>();

             Vector3 pos = transform.position;

             float mouseX = Input.mousePosition.x;
             float mouseY = Input.mousePosition.y;

             // --- 📸 화면 끝 감지 후 카메라 이동 ---
             if (mouseY >= Screen.height - borderThickness)
             {
                 pos += Vector3.forward * moveSpeed * Time.deltaTime; // 위쪽(앞)
             }
             if (mouseY <= borderThickness)
             {
                 pos += Vector3.back * moveSpeed * Time.deltaTime; // 아래쪽(뒤)
             }
             if (mouseX >= Screen.width - borderThickness)
             {
                 pos += Vector3.right * moveSpeed * Time.deltaTime; // 오른쪽
             }
             if (mouseX <= borderThickness)
             {
                 pos += Vector3.left * moveSpeed * Time.deltaTime; // 왼쪽
             }

             transform.position = pos;

             //스페이스바 입력 값에 따른 점프 버튼 처리
             bool isJump = inputActions.Camera.Jump.ReadValue<bool>();
             if (isJump)
             {
                 Debug.Log("jump 버튼을 눌렀습니다.");
             }

         }
        #endregion

        #region Unity Event Method
      /*  private void Update()
        {
            //카메라 이동
            //이동 : 방향 * Time.Deltatime * moveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y); //방향 구하기
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
        }*/
        #endregion

        #region Custom Method - SendMessage
        /*public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();

        }

        public void OnJump(InputValue.value)
        {
            if (value.isPressed)
            {
                Debug.Log("점프 버튼을 눌렀습니다");
            }
        }
        ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ*/
        /*public void Move(InputAction.CallbackContext context)
        { 
            inputVector = context.ReadValue<Vector2>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            { 
                //실행문
            }
        }
ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ*/
        public void Jump(InputAction.CallbackContext context)
        {
            //context.started = 
            //context.cancaled = 
            //context.performed = 
            if (context.performed)
            {
                //실행문
            }
        }

        #endregion
    }
}
/*
1.Input Actions Editor 창 셋팅하기
- Action Map 셋팅 (ex: Camera)
- Action 셋팅 (ex: Move, Jump)

ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

2.New Input System 에서 유저 인풋값 가져오기

 -1) 스크립트를 이용하여 값 가져오기 
  Input Actions 셋팅을 Class 파일로 만들어서 처리한다
  만들어진 Class의 객체를 생성해서 인풋 값 처리

 -2) SendMessage 방법
 - Player Input 컴포넌트 추가 : 액션멥 바인딩 - 드래그
 - Behaviour 를 SendMMessage 셋팅
 - 인풋 대응 함수 만들기 
 - 함수 이름 규칙: On + 액션이름 (InputValue value)
  
 -3) Unity Event 등록 방법
 - Player Input 컴포넌트 추가 : 액션멥 바인딩 - 드래그
 - Behaviour 를 Unity Event 셋팅
 - 인풋 대응 함수 만들기
 - 이름 규칙 없음, 매개변수는 규칙 있다
public void 함수이름 (InputAction.CallbackContext context)
 - 만든 함수를 대응되는 이벤트에 등록한다

 */