using UnityEngine;

namespace Sample
{
    //MonoBehaviour를  상속받은 클래스 싱글톤 패턴 디자인
    //= Unity에서 게임 오브젝트에 부착되는 클래스의 싱글톤 패턴 디자인 / 싱글톤 : 하나만 존재, 전역적 접근이 가능
    public class SingletonMono : MonoBehaviour
    {
        //클래스의 인스턴스 (객체)를 정적(static) 변수 선언
        private static SingletonMono instance;

        //public한 속성으로 instance에 전역적으로 접근하기
        public static SingletonMono Instance
        {
            get
            {
                //이미 MonoBehaviour에서 new해줬으니(생성자) 따로 생성 안해도 됨
                //MonoBehaviour가 없는 빈 클래스 에서는 따로 null을 대비해 if문 생성해야함 
                return instance;
            }
        }

        //
        private void Awake()
        {
            //다른 오브젝트에서 인스턴스가 이미 생성되어 있는가를 확인 
            //instance가 존재하면 this 오브젝트 외에는 킬한다
            if (instance != null)
            { 
               Destroy (this.gameObject);
               return;
            } 
            instance = this; // 생성되어 있던 인스턴스를 가져와서 저장

            //씬 종료시 이 스크립트 부착되어 있는 오브젝트는 삭제하지 않는다
            DontDestroyOnLoad(this.gameObject);
        }

        //필드
        public int number;
        


    }
}