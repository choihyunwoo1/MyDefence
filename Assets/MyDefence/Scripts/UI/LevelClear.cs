using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 레벨클리어 UI 관리하는 클래스
    /// </summary>
    public class LevelClear : MonoBehaviour
    {
        #region Variables
        public SceneFader Fader;
        string loadToScene = "MainMenu";

        [SerializeField]
        string nextScene = "Level02";
        #endregion

        #region Custom Method 
        //넥스트레벨 버튼 클릭시 호출
        public void NextLevel()
        {
            Fader.FadeTo(nextScene);
        }

        //메인메뉴 버튼 클릭시 호출
        public void MainMenu()
        {
            Fader.FadeTo(loadToScene);
        }
        #endregion
    }
}