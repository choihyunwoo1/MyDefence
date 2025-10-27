using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class UITest1 : MonoBehaviour
    {
        public Button skill;

        //스킬 사용 가능여부
        public bool ischarge=false;

        //쿨 타이머
        public float cooltime =5f;
        float countdown = 0f;

        public Image cooling;

        private void Start()
        {
            ischarge = true;
            countdown = 0f;
        }

        private void Update()
        {
            //스킬버튼 쿨 타이머
            if (ischarge == false)
            {
                countdown += Time.deltaTime;
                if (countdown >= cooltime)
                { 
                    //타이머 기능 - 스킬 활성화
                    ischarge=true; 
                    skill.interactable = true;

                    //타이머 초기화
                   // countdown = 0f;
                }
                // countdown에 맞추어 fill 360도 회전
                // % : 현재값량 / 총값량
                cooling.fillAmount = countdown / cooltime ;
            }
        }

        public void Click()
        {
           if ( ischarge == false)
           {
                return; 
           }

            Debug.Log("click");

            //재초기화
            ischarge = false;
            //버튼 비활성화
            skill.interactable =false;
            countdown = 0f;
        }
    }
}