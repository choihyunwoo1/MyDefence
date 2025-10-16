using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임중 가지고 있는 Money를 그리는 UI 클래스
    /// </summary>
    public class DrawMoney : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI moneyText;
        #endregion

        #region Property

        #endregion

        #region Unity Event Mehod
        void Update()
        { 
            //Money 데이터 UI 적용
            moneyText.text = PlayerStats.Money.ToString();
        }
        #endregion

        #region Custom Method

        #endregion
    }
}