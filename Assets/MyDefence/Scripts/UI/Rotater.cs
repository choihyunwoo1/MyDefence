using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 회전 시켜주는 클래스
    /// </summary>
    public class Rotater : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private Vector3 rotationSpeed;
        #endregion

        #region Unity Event Method
        public void Update()
        {
            transform.localEulerAngles += rotationSpeed; //Time.Deltatime은 밸런스에 관계 없으므로 생략.
        }
        #endregion
    }
}