using UnityEngine;

namespace Sample
{
    //싱글톤 패턴 클래스
    public class SingleTon
    {
        //클래스의 인스턴스 (객체)를 정적(static) 변수 선언
        private static SingleTon instance;

           //public한 속성으로 private한 인스턴스에 전역적으로(static) 접근이 가능
        public static SingleTon Instance
        {
            get
            {
                if (instance == null) //new로 인스턴스가 생성되지 않았을때 null이 반환된다
                { 
                    //인스턴스 생성
                    instance = new SingleTon(); //그럴때 생성해드려요~
                }
                return instance;
            }
        }                                             

/*        //public한 메서드로 instance에 전역적 접근(static)
        public static SingleTon Instance()
        {
            if (instance == null)
            { 
                instance = new SingleTon();
            }
            return instance; 
        }*/

        //필드 : 인스턴스이름.number
        public int number;

    }
}

/*
Singleton.instance = private이라 불가능(외부에서 사용불가)
Singleton.Instance = 읽기전용 public한 속성으로 접근가능

private static
ex) SingleTon.Instance.a = 10;

Debug.Log(SingleTon.Instance.a.ToString());
 mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
public static
ex) SingleTon.Instance().a = 10;

Debug.Log(SingleTon.Instance().a.ToString());

 */