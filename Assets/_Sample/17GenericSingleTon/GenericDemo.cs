using UnityEngine;

namespace Sample
{
    public class GenericDemo : MonoBehaviour
    {
        private void Start()
        {
            //Cup 클래스의 객체 생성
            //Cup c = new Cup(); - 제네릭이라 불가능

            //[1] T에 string 형식으로 지정하여 Cup 클래스의 객체 생성
            Cup<string> text = new Cup<string>(); // 문자열 저장 가능
            text.content = "문자열";

            //[2] int형으로 저장
            Cup<int> number = new Cup<int>();
            number.content = 1234;

            Debug.Log($"{text.content}+{number.content}");

            //[3] T에 water 형식으로 지정하여 Cup클래스의 객체 생성 - 커스텀클래스 형식으로 지정가능
            Cup<water> water = new Cup<water>();
            water.content = new water();
            Debug.Log(water.content.ToString());

            //[4]Singleton<T>을 상속받는 테스트 클래스
            TestManager.Instance.number = 5678;
            Debug.Log(TestManager.Instance.number.ToString());

            //[5]PersistantSingleton<T>를 상속받는 클래스
            TestManager2.Instance.name = "백두산";
            Debug.Log(TestManager2.Instance.name);

        }
    }
}