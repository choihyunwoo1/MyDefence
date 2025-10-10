using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 카메라 제어 : 이동, 줌인,아웃
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        #region Variables
        public float moveSpeed = 10f; //카메라 이동 속도

        public float borderThickness = 10f; // 스크린 가장자리 감지 영역 (픽셀 단위)
        public float minX = -50f, maxX = 50f; // 맵 제한 (X축)
        public float minZ = -50f, maxZ = 50f; // 맵 제한 (Z축)

        public float zoomSpeed = 500f;        // 줌 속도 (휠 민감도)
        public float minY = 10f;              // 최소 높이 (줌인 한계)
        public float maxY = 50f;              // 최대 높이 (줌아웃 한계)

        public bool isCannotMove = false;
        #endregion

        #region Unity Event Method
        void Update()
        {
            // ESC 누를 때마다 이동 가능/불가능 전환
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isCannotMove = !isCannotMove; // true ↔ false 전환
                Debug.Log($"카메라 이동 {(isCannotMove ? "OFF" : "ON")}");
            }

            if (isCannotMove)
                return;

            //<Global기준>
            //W키를 입력하면 앞으로 이동
            if (Input.GetKey(KeyCode.W))
            {
                // 자신의 앞 방향(=Z축)으로 이동
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
            }
            //S키를 입력하면 뒤로 이동
            if (Input.GetKey(KeyCode.S))
            {
                // 자신의 앞 방향(=Z축)으로 이동
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
            }
            //A키를 입력하면 왼쪽으로 이동
            if (Input.GetKey(KeyCode.A))
            {
                // 자신의 앞 방향(=Z축)으로 이동
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
            }
            //D키를 입력하면 오른쪽으로 이동
            if (Input.GetKey(KeyCode.D))
            {
                // 자신의 앞 방향(=Z축)으로 이동
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            }

            //마우스를 스크린 상하좌우 끝 부분(기준 폭: 10)에 가져가면 맵을 스크롤 시킨다
            Vector3 pos = transform.position;

            // --- 🎯 마우스 위치 감지 ---
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

            //마우스 스크롤 기능을 입력받아 줌인,줌 아웃 (높이조절)기능 구현
            // --- 🔍 마우스 휠 줌 기능 ---
            float scroll = Input.GetAxis("Mouse ScrollWheel"); // 휠 위: +값, 아래: -값
            pos.y -= scroll * zoomSpeed * Time.deltaTime; // y축 이동으로 줌 효과

            // --- ⚙️ 이동/줌 범위 제한 ---
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // --- ✅ 최종 위치 적용 ---
            transform.position = pos;
        }
        #endregion

        #region Custom Method
        #endregion
    }
}