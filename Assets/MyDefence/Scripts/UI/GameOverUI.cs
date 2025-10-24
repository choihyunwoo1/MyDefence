using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        //Rounds 텍스트
        public TextMeshProUGUI roundsText;
        #endregion

        #region Unity Event MEthod
        //게임오버 UI가 활성화 될때 PlayerStats.Rounds의 값을 한번만 가져온다.
        private void OnEnable()
        {
            //Rounds 텍스트에 PlayerStats의 Rounds값 적용
            roundsText.text = PlayerStats.Rounds.ToString() + "ROUNDS SURVIVED";
        }

        //매 프레임 마다 PlayerStats.Rounds의 값을 가져온다.
        /*private void Update()
        {
            //Rounds 텍스트에 PlayerStats의 Rounds값 적용
            roundsText.text = PlayerStats.Rounds.ToString() + "ROUNDS SURVIVED";
        }*/
        #endregion

        public void MainMenu()
        {
            Debug.Log("메뉴로 돌아갑니다");
            SceneManager.LoadScene("MainMenu");
        }

        public void Restart()
        {
            Debug.Log("다시 시작합니다");

            //웨이브 초기화
            //돈 초기화, 라이프 초기화
            //타워 제거....

            //현재 플레이중인 SCENE(씬)을 재호출한다. = 리플레이
            SceneManager.LoadScene("PlayScene");  //인덱스로 불러오기
            //SceneManager.LoadScene("PlayScene"); - 씬 이름으로 불러오기

            //int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            //string noewSceneName = SceneManager.GetActiveScene().name;
        }


    }
}