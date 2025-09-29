using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// Enemy
    /// </summary>
    public class Enemy2 : MonoBehaviour
    {
        #region Variable
        //이동 목표 위치를 가지고 있는 오브젝트
        public Transform target;
        //이동속도
        public float speed = 10f;
        #endregion

        #region
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            target = WayPoints.points[0];
        }

        // Update is called once per frame
        void Update()
        {
            //타겟을 향해 이동해라
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);

            //도착 판정 - 타겟과 Enemy의 거리
            float Distance = Vector3.Distance(target.position, this.transform.position);
            if (Distance <= 0.5f)
            {
                Arrive();
            }
        }
        #endregion

        #region Custom Method
        private void Arrive()
        {
            Destroy(this.gameObject);
            Debug.Log("도착했다");
        }
        #endregion

    }
}