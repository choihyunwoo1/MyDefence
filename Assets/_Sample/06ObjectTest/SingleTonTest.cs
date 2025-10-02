using UnityEngine;

namespace Sample
{
    public class SingleTonTest : MonoBehaviour
    {
        private void Start()
        {
            //정적 멤버 변수 사용하기(전역적 접근)
            StaticTest.number = 20;
            Debug.Log (StaticTest.number.ToString());


             //싱글톤 패턴 클래스 인스턴스 생성
            /* SingleTon singleTon = new SingleTon();
             Debug.Log(singleTon.ToString());*/// - SingleTon클래스는 new해서 사용하지 않는다

            var singletonA = SingleTon.Instance; 
            var singletonB = SingleTon.Instance;
            if (singletonA == singletonB)
            {
                Debug.Log(singletonA.ToString());
            }

            SingleTon.Instance.number = 10;
            Debug.Log(SingleTon.Instance.number.ToString());

            //MonoBehaviour를  상속받은 싱글톤 클래스
            SingletonMono.Instance.number = 40;
            Debug.Log(SingletonMono.Instance.number.ToString());
        }
    }
}
/*
디자인패턴
싱글톤(singleton) 패턴
: 하나의 인스턴스만 존재 : new를 한번만 한다
: 클래스에 인스턴스가 전역적 접근이 가능하다 : 인스턴스 변수를 static으로 선언

: 싱글톤의 클래스의 인스턴스 변수는 자신 클래스 코드블록 안에서 선언한다

 */