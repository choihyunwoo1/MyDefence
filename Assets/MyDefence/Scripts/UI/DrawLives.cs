using TMPro;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 게임중 가지고 있는 Life를 그리는 UI 클래스
    /// </summary>
    public class DrawLives : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI livesCount;
        #endregion

        #region Unity Event Method
             void Update()
        {
            //Lives 데이터 UI 적용
            livesCount.text = PlayerStats.Lives.ToString();
        }
        #endregion
    }
}