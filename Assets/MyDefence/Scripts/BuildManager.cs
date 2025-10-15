using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 건설을 관리하는 싱글톤 클래스
    /// </summary>
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        #region Variables
        //타일에 설치할 프리팹 오브젝트를 저장하는 변수
        //여러개의 타워 프리팹중 선택된 프리팹을 저장하는 변수
        private TowerBlueprint towerToBuild;
        #endregion

        #region Property
        //건설 불가능 여부 체크
        public bool CannotBuild
        { 
            get { return towerToBuild == null; }
        }

        //건설 비용이 부족
        public bool HasBuildCost
        {
            get 
            {
                if (towerToBuild == null)
                    return false;

                return PlayerStats.HasMoney(towerToBuild.cost);
            }
        }
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //초기화 - 임시
            //turretToBuild = machineGunPrefab;
        }
        #endregion

        #region CustomMethod
        public TowerBlueprint GetTurretToBuild()
        {
            return towerToBuild;
        }

        public void SetTurretToBuild(TowerBlueprint tower)
        {
            towerToBuild = tower;
        }
        #endregion
    }
}
