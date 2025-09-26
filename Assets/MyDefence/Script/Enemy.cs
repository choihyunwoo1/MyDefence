using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// Enemy
    /// </summary>

    #region
    public class Enemy : MonoBehaviour
    {
        #region Variable
        public float speed = 3f;
        public Transform target;
        #endregion

        // Update is called once per frame
        void Update()
        {
            #region translate 활용
            // (목표위치 - 현재위치) = 방향 벡터
            //Vector3 dir = (target.position - transform.position).normalized;

            // 방향 * 속도 * 시간 = 이동 거리
            //transform.Translate(dir * speed * Time.deltaTime);
            #endregion

           
            // MoveTowards 문법
            //Vector3.MoveTowards(Vector3 현재위치, Vector3 목표위치, float 최대이동거리);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("End"))
            {
                Destroy(gameObject);
            }
        }

    }
}