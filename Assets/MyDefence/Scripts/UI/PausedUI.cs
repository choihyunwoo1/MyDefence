using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// Pause UI를 관리하는 클래스
    /// </summary>
    public class PausedUI : MonoBehaviour
    {
        #region Variables
        public GameObject paused;
        #endregion 

        #region Unity Event Method
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }
        #endregion

        #region Custom Method
        public void Toggle()
        {
            paused.SetActive(!paused.activeSelf);

            if (paused.activeSelf) //창이 열려있는가?
            {
                Time.timeScale = 0f;
            }
            else  //창이 닫혀있는가?
            {
                Time.timeScale = 1f;
            }
        }

        public void MainMenu()
        {
            Debug.Log("Goto MainMenu!");
            //Time.timeScale = 1f;
        }

        public void Restart()
        {
            //현재 플레이하고 있는 씬을 새로 로드하기
            int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(0);
            //Debug.Log("Restart!");

            Time.timeScale = 1f;
        }




        #endregion

    }
}