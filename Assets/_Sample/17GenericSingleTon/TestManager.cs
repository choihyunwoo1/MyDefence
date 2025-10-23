using UnityEngine;

namespace Sample
{
    /// <summary>
    /// Singleton<T>을 상속받는 테스트 클래스
    /// </summary>
    public class TestManager : SingleTon<TestManager> //자기자신의 클래스 이름
    {
        public int number = 1234;

    }
}