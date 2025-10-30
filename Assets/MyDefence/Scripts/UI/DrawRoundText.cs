using UnityEngine;
using TMPro;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// 라운드 넘버 텍스트를 카운팅 애니메이션 연출
    /// 라운드 숫자를 15, 0~15까지 카운팅하는 애니메이션 연출(코루틴)
    /// </summary>
    public class DrawRoundText : MonoBehaviour
    {
        #region Variables
        //라운드 넘버 텍스트
        public TextMeshProUGUI roundsText;
        #endregion

        #region Unity Event Method
        private void OnEnable()
        {
            StartCoroutine(AnimateNumberText(15));
        }
        #endregion

        #region Custom Method
        //매개 변수로 입력받은 숫자 카운팅 애니메이션
        IEnumerator AnimateNumberText(int targetNumber)
        {
            int number = 0;
            roundsText.text = number.ToString();
            yield return new WaitForSeconds(0.2f);

            while (number < 15)
            { 
                number++;
                roundsText.text = number.ToString();

                yield return new WaitForSeconds(0.1f);
            }
        }
        #endregion
    }
}