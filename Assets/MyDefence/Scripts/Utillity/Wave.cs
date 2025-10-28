using UnityEngine;
using System;

namespace MyDefence
{
    /// <summary>
    /// 웨이브를 관리하는 클래스
    /// </summary>
    [Serializable]
    public class Wave
    {
        public GameObject prefab;
        public int count;
        public float delayTime;
    }
}