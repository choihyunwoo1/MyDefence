using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워 선택 UI를 관리하는 클래스
    /// </summary>
    public class BuildMEnu : MonoBehaviour
    {
        #region Variables
        //싱클톤 객체 선언
        private BuildManager buildManager;

        public TowerBlueprint machineGun;
        public TowerBlueprint rocketTower;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            buildManager = BuildManager.Instance;
        }
        #endregion


        #region Custom Method
        //머신건 버튼 선택시 호출되는 함수
        public void SelectMachineGun()
        {
            //turretToBuild = machineGunPrefab;
            Debug.Log("머신건 타워를 선택 하였습니다!!!");
            // private한 필드라 읽기전용 public함수를 통해 머신건프리팹을 초기화
            BuildManager.Instance.SetTurretToBuild(machineGun);
        }

        //다른타워 선택시 호출되는 함수
        public void SelectRocketTower()
        {
            Debug.Log("로켓 타워를 선택 하였습니다!!!");
            BuildManager.Instance.SetTurretToBuild(rocketTower);
        }

        #endregion

    }
}