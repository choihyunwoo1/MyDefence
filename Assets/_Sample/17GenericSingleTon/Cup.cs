using UnityEngine;

namespace Sample
{
    public class water { }
    public class coffee { }

    //Generic 클래스 만들기 = 클래스 이름<T>
    public class Cup<T> // Cup of T - T는 형식 매개변수
    {
        public T content { get; set; }
        
        
        public void PrintData(T data)
        {
            Debug.Log(data.ToString());
        }
    }
}