using TMPro;
using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 소지금 연산 예제
    /// </summary>
    public class MoneyTest : MonoBehaviour
    {
        #region Variables
        //소지금
        private int gold;

        //초기 소지금
        [SerializeField]
        private int startGold = 1000;

        public TextMeshProUGUI goldText;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //게임을 진행했으면 저장된 데이터를 가져와서 실행

            //초기화
            gold = startGold; //초기 소지금 지급
        }
        private void Update()
        {
            goldText.text = gold.ToString()+gold;
        }
        #endregion

        #region Custom Method
        public void Save1000()
        {
            Debug.Log("1000 Gold Save");
            AddGold(1000);
        }


        public void purchase1000()
        {
            if (UseGold(1000) == true)
            {
                Debug.Log("1000 Item Purchase");
            }
        }

        public void purchase9000()
        {
            if (UseGold(9000) == true)
            {
                Debug.Log("9000 Item Purchase");
            }
        }

        //돈, Gold
        //돈을 번다: 사냥, 퀘스트, 캐쉬, 초기 소지금, 선물받기
        public void AddGold(int amount)
        {
            gold += amount;
        }

        //돈을 쓴다: 아이템 구매, 기구 사용, 건설 비용, 선물하기 등등...
        //돈이 부족하면 돈을 사용하지 않고 return false;
        //돈이 충분하면 돈을 사용하고 return true;
        public bool UseGold(int amount)
        {
            //소지금 체크
            if (gold < amount)
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            gold -= amount;
            return true;
        }

        //소지금 체크, 잔고 확인
        public bool HasGold(int amount)
        { 
            return gold > amount;
        }
        #endregion
    }
}