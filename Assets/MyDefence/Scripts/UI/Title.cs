using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// Title 씬을 관리하는 클래스
    /// </summary>
    public class Title : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private string loadToScene = "MainMenu";

        float countDown = 0f;
        float titleTimer = 10f;

        public GameObject AnkeyUI;

        float showTimer = 3f;
        bool isShow = true;

        Coroutine titleCoroutine;
        #endregion

        #region Unity Event Method

        private void Start()
        {
            //10초가 지나면 AnyKey를 보여준다 - 지연함수 사용 Invoke
            //Invoke("ShowAnyKey", 3f);
            //Invoke("GotoMainMenu", titleTimer + showTimer);

            //코루틴 지연함수 겸 오류방지로 초기화
            titleCoroutine = StartCoroutine(TitleProcess());

        }

        private void Update()
        {
            //쇼타일 체크
            if (isShow == false)
                return;


           /* countDown += Time.deltaTime;
            if (countDown > titleTimer)
            {
                GotoMainMenu();

                countDown = 0f;
                return;
            }*/

            //아무 키를 누르면 메인메뉴 씬 이동
            if (Input.anyKeyDown)
            {
                // 코루틴이 실행 중이라면 멈춤
                if (titleCoroutine != null)
                {
                    StopCoroutine(titleCoroutine);
                    titleCoroutine = null;
                }

                GotoMainMenu();
            }
        }
        #endregion

        #region Custom Method
        void GotoMainMenu()
        {
            SceneManager.LoadScene(loadToScene);
        }

        void ShowAnyKey()
        {
            isShow = true;
            AnkeyUI.SetActive(true);
        }

        IEnumerator TitleProcess()
        { 
            yield return new WaitForSeconds(showTimer);
            ShowAnyKey();

            yield return new WaitForSeconds(titleTimer);
            GotoMainMenu();
        }


        #endregion
    }
}