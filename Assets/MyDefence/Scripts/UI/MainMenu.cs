using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// MainMenu를 관리하는 클래스
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        string loadToScene = "PlayScene";
        string loadToTitle = "Title";
        #endregion

        #region Custom Method
        //플레이버튼 클릭시 호출되는 함수
        public void Play()
        {
            Debug.Log("play");    
            SceneManager.LoadScene(loadToScene);
        }

        //게임 나가기 버튼 클릭시 호출되는 함수
        public void Quit()
        {
            Debug.Log("Quit");
            //Application.Quit(); //에디터에서는 명령 무시, 실행 파일에서는 명령 실행
            
            SceneManager.LoadScene(loadToTitle);
        }
        #endregion


    }
}