using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence
{
    /// <summary>
    /// 타일 UI를 관리하는 클래스
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        #region Variables
        //타일 UI 오브젝트
        public GameObject ui;

        //선택된 타일
        private Tile targetTile;

        //UI 연결
        public TextMeshProUGUI upgradeCostText;

        //업그레이드 버튼 컴포넌트 가져오기
        public Button upgradeButton;

        //판매 가격 text
        public TextMeshProUGUI sellCostText;
        #endregion

        #region Property

        #endregion

        #region Unity Event Method
        private void Update()
        {
            
        }
        #endregion

        #region Custom Method
        //타일 UI 보여주기 (매개변수로 선택된 타일의 정보를 가져옵니다.)
        public void ShowTileUI(Tile tile)
        { 
            //내가 선택된 타일 위치에서 보여주기 - 타일의 포지션을 가져온다.
            targetTile = tile;
            this.transform.position = tile.transform.position;
                
            //타일 UI 셋팅
            if (targetTile.isUpgradeCompleted) //타일의 타워가 업그레이드 되었으면
            {
                upgradeCostText.text = "DONE";
                upgradeButton.interactable = false;
            }
            else //그렇지 않다면
            {
                upgradeCostText.text = targetTile.blueprint.upgradeCost.ToString() + "G";
                upgradeButton.interactable = true;
            }

            //판매 가격을 string형식으로 치환
            sellCostText.text = targetTile.blueprint.GetSellCost().ToString() + "G";

            ui.SetActive(true);
        }
        //타일 UI 숨기기
        public void HideTileUI()
        { 
            targetTile = null; //초기화
            ui.SetActive(false);
        }

        //업그레이드 버튼을 선택했습니다.
        public void Upgrade()
        {
           // Debug.Log("설치된 타워를 업그레이드 합니다.");
            targetTile.UpgradeTower();
        }

        //판매 버튼을 선택 하였습니다.
        public void Sell()
        {
            // Debug.Log("설치된 타워를 판매합니다.");
            targetTile. SellTower();
        }

        #endregion

    }
}