using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

namespace Sample
{
    /// <summary>
    /// Old Input Test
    /// </summary>
    public class InputTest : MonoBehaviour
    {
        #region Varialbes
        float centerX;
        float centerY;

        public TextMeshProUGUI positionText;
        #endregion

        #region Unity Event Method
        void Start()
        {
            //스크린의 크기
            Debug.Log($"Screen Width : {Screen.width}");
            Debug.Log($"Screen Height : {Screen.height}");
            centerX = Screen.width / 2;
            centerY = Screen.height / 2;
            Debug.Log($"{centerX},{centerY}");
        }

        private void Update()
        {
           /* //GetKey - 계속 입력
            if (Input.GetKey("w")) //소문자 입력
            {
                Debug.Log("W키를 누르고 있습니다.");
            }
            //GetKeyDown - 한번만 입력
            if (Input.GetKeyDown(KeyCode.W)) 
            {
                Debug.Log("W키를 눌렀습니다.");
            }
            //GetKeyUp - 떼어졌을때 입력 (GetKeyDown과 함꼐 활용)
            if (Input.GetKeyUp(KeyCode.W))
            {
                Debug.Log("W키를 눌렀다가 떼었습니다.");
            }


            //GetButton - InputManager 정의된 Axes(버튼) 이름을 가져와서 사용한다
            if (Input.GetButton("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)를 누르고 있습니다.");
            }
            //GetButtonDown - 한번만 입력
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)를 눌렀습니다.");
            }
            //GetButtonUp - 떼어졌을때 입력 (GetButtonDown과 함꼐 활용)
            if (Input.GetButtonUp("Jump"))
            {
                Debug.Log("점프 버튼(스페이스바)를 눌렀다가 떼었습니다.");
            }*/


            //GetAxis - InputManager 정의된 Axis(버튼) 이름을 가져와서 사용한다
            //if (Input.GetButton("Horizontal"))
            {
                //a, left : -1 ~ 0
                //d, right : 0 ~ 1
                //입력이 없으면 : 0
                //float hValue = Input.GetAxis("Horizontal");
                //Debug.Log($"Horizontal GetAxis : {hValue}");
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                //a, left : -1
                //d, right : 1
                //입력이 없으면 : 0
                float hValue = Input.GetAxisRaw("Horizontal");
                Debug.Log($"Horizontal GetAxisRaw : {hValue}");
            }

            //if (Input.GetButton("Vertical"))
            {
                //s, Down : -1 ~ 0
                //w, Up : 0 ~ 1
                //입력이 없으면 : 0
                //float vValue = Input.GetAxis("Vertical");
                //Debug.Log($"Vertical GetAxis : {vValue}");
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                //s, Down : -1
                //w, Up : 1
                //입력이 없으면 : 0
                float vValue = Input.GetAxisRaw("Vertical");
                Debug.Log($"Vertical GetAxisRaw : {vValue}");
            }

            //스크린상에서 마우스 위치값 가져오기 - Vector3의 값
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            //Debug.Log($"Mouse Position : {mouseX}, {mouseY}");
            positionText.text = $"{(int)mouseX},{(int)mouseY}";
            positionText.rectTransform.position = new Vector2 (mouseX, mouseY);
        }
        #endregion

        #region Custom Method
        #endregion
    }
}