using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 온오프 기능 정의
    /// </summary>
    public interface ISwitchable //문 역할
    {
        public bool IsActive { get; set; }

        public void Activate(); //open
        public void Deactivate(); //close
    }
}