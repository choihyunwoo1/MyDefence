using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace MyDefence
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //타일에 설치된 타워 오브젝트 blueprint 객체(프리팹 정보, 가격정보, 설치 조정위치...)
        private TowerBlueprint blueprint;

        //랜더러 컴포넌트 인스턴스 변수 선언
        private new Renderer renderer;

        //마우스가 들어가면 바뀌는 컬러
        public Color hoverColor;
        //타일의 원래 색깔
        private Color startColor;

        //마우스가 들어가면 바뀌는 메터리얼
        public Material hoverMaterial;
        //타일의 원래 메터리얼
        private Material startMaterial;

        //건설 비용 부족 메터리얼
        public Material moneyMaterial;

        //타워 건설 효과
        public GameObject buildEffectPrefab;
        
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            startColor = renderer.material.color;
            startMaterial = renderer.material;

        }

        private void OnMouseDown()
        {
            //UI로 가려져 있으면 설치 못한다
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타워를 선택하지 않았으면 설치하지 못한다
            if (BuildManager.Instance.CannotBuild)
            {
                Debug.Log("설치할 타워가 없습니다!");
                return;
            }

            //만약 타일에 타워오브젝트가 있으면 설치하지 못한다
            if (tower != null)
            {
                Debug.Log("타워를 설치하지 못합니다");
                return;
            }

            blueprint = BuildManager.Instance.GetTurretToBuild();

            //Debug.Log("마우스가 좌클릭하여 타일 선택 - 여기에 타워 건설");
            BuildTower();
        }

        private void OnMouseEnter()
        {
            //UI로 가려져 있으면 설치 못한다
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //만약 타워를 선택하지 않았으면 변경되지 않는다
            if (BuildManager.Instance.CannotBuild)
            {
                return;
            }

            //건설비용 체크
            if (BuildManager.Instance.HasBuildCost)
            {
                renderer.material = hoverMaterial;
            }
            else
            { 
                renderer.material = moneyMaterial;
            }

                //renderer.material.color = hoverColor;
                //renderer.material = hoverMaterial;
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            renderer.material = startMaterial;
        }
        #endregion

        #region Custom Method
        //타워 건설
        private void BuildTower()
        {
            //건설비용 체크
            if (BuildManager.Instance.HasBuildCost == false)
            {
                Debug.Log("건설 비용이 부족합니다");
                return;
            }

            //건설 비용 지불
            PlayerStats.UseMoney(blueprint.cost);


            //타워 건설
            tower = Instantiate(blueprint.prefab, this.transform.position + blueprint.offsetPos, Quaternion.identity);

            //파티클 생성, 생성하자마자 kill 예약
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //turretToBuild를 null로 만든다 - 건설 후 재건설 불가능하게 null로 비워준다
            // = OnMouseDown의 turret != null 구문에서 걸린다
            BuildManager.Instance.SetTurretToBuild(null);

            Debug.Log($"건설하고 남은 소지금: {PlayerStats.Money}");
        }  
        #endregion
    }
}
