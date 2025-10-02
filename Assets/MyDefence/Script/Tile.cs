using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    public class Tile : MonoBehaviour
    {

        #region Variables
        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //렌더러 컴포넌트 인스턴스 변수 선언
        private Material originalMaterial; // 원래 색 저장
        private Renderer orenderer;

        //색 메터리얼
        public Material colormaterial;

        //타워 프리팹
        //빌드매니저 클래스 사용중이라 대체됨
        #endregion

        #region Unity Event Method
        private void Start()
        {
            orenderer = GetComponent<Renderer>();
            originalMaterial = orenderer.material;
        }

        void OnMouseDown()
        {
            //만약 타일에 타워오브젝트가 있으면 설치하지 못한다
            //아래의 변수에 저장해놓았기 때문에 리턴된다
            if (tower != null)
            {
                Debug.Log("이미 설치된 타워가 있습니다.");
                return;
            }

            tower = Instantiate(BuildManager.Instance.GetTurretToBuild(), this.transform.position, Quaternion.identity); //여기서 초기화(저장)
            Debug.Log("마우스가 좌클릭하여 타일 선택 - 여기에 타워 건설");
        }

        void OnMouseEnter()
        {
            orenderer.material = colormaterial;
        }
        void OnMouseExit()
        {
            orenderer.material = originalMaterial;  // 원래 머티리얼로 복구
        }

        #endregion

        #region Custom Method
        #endregion
    }
}