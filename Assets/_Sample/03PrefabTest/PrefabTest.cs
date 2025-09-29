using UnityEngine;
using System.Collections;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables(변수 선언)
        //프리팹 오브젝트
        //public GameObject prefab;

        public GameObject prefab;  // 찍어낼 프리팹
        //public Transform parent;
        public int rows = 10;      // 행 개수
        public int cols = 10;      // 열 개수
        public float spacing = 2f; // 간격
        #endregion

        #region Unity Event Method
        public void Start()
        {
           StartCoroutine(CreateMapTile());
           Debug.Log("타일 생성 완료"); //두번째로 출력됨

            //[1] 
            //Instantiate(prefab); - 하이라키 창에 생성
            //위치: (5, 0, 8)맵타일 생성하기 - 특정 위치에 생성
            //Instantiate(prefab, 위치, 방향);
            //'Vector3 position = new Vector3 (5f, 0f, 8f); //위치지정
            // Instantiate(prefab,position, Quaternion.identity);
            // Instantiate (prefab,new Vector3(5f, 0f, 8f), Quaternion.identity);


           /* //10X10의 타일맵 생성, 타일간 간격은 1이다
            for (int i = 0; i < rows; i++)       // 행 루프
            {
                for (int j = 0; j < cols; j++)   // 열 루프
                {
                    // 위치 계산
                    //Vector3 position = new Vector3(i * spacing, 0, j * spacing);

                    // 프리팹 생성
                    //Instantiate(prefab, position, Quaternion.identity,this.transform);

                    // 인스턴스 후 위치 지정 - 생성된 게임오브젝트(transform) 객체 가져오기
                    GameObject go = Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0, j * -5f);
                }
            }*/

        }
        #endregion

       private void Update()
        {
           /* Debug.Log("코루틴 시작");
            StartCoroutine(CreateMapTile());
            Debug.Log("타일 생성 완료");*/
        }

        #region custom Method
        public void GenerateMap()
        {

            //10X10의 타일맵 생성, 타일간 간격은 1이다
            for (int i = 0; i < rows; i++)       // 행 루프
            {
                for (int j = 0; j < cols; j++)   // 열 루프
                {
                    // 위치 계산
                    Vector3 position = new Vector3(i * 5f, 0, j * -5f);

                    // 프리팹 생성
                    Instantiate(prefab, position, Quaternion.identity);
                }
            }
        }
        #endregion

        //맵 제너레이터를 부모로 지정하며 맵 타일 찍기
        void GnerateMapTile()
        {
            //10X10의 타일맵 생성, 타일간 간격은 1이다
            for (int i = 0; i < rows; i++)       // 행 루프
            {
                for (int j = 0; j < cols; j++)   // 열 루프
                {
                    // 인스턴스시 위치 지정
                    Vector3 position = new Vector3(i * 5f, 0, j * -5f);
                    Instantiate(prefab, position, Quaternion.identity);

                    // 인스턴스 후 위치 지정
                    Instantiate(prefab, this.transform);

                }
            }
        }

        // 10열 10행 중 랜덤한 위치에 타일 하나 찍기
        void GenerateRandomMapTile()
        {
            //int row = Random.Range(0, 10);
            //int column = Random.Range(0, 10);

            //0에서 100까지 랜덤 숫자
            //0행 , (0~100)열
            int randomnum = Random.Range(0, 100);
            int row = randomnum / 10;
            int column = randomnum % 10;

            Vector3 position = new Vector3(row * 5f, 0, column * -5f);
            Instantiate(prefab, position, Quaternion.identity, this.transform);

        }

        //랜덤 타일을 1초 간격으로 10개 찍는다
        IEnumerator CreateMapTile()
        {
            GenerateRandomMapTile();
            Debug.Log("첫번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("두번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("세번째 타일 생성");
            yield return new WaitForSeconds(1.0f);


            GenerateRandomMapTile();
            Debug.Log("네번째 타일 생성");
            yield return new WaitForSeconds(1.0f);


            GenerateRandomMapTile();
            Debug.Log("다섯번째 타일 생성");
            yield return new WaitForSeconds(1.0f);


            GenerateRandomMapTile();
            Debug.Log("여섯번째 타일 생성");
            yield return new WaitForSeconds(1.0f);


            GenerateRandomMapTile();
            Debug.Log("일곱번째 타일 생성");
            yield return new WaitForSeconds(1.0f);


            GenerateRandomMapTile();
            Debug.Log("여덟번째 타일 생성");
            yield return new WaitForSeconds(1.0f);


            GenerateRandomMapTile();
            Debug.Log("아홉번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("열번째 타일 생성");
            yield return new WaitForSeconds(1.0f);
        }






    }
}
/*
 코루틴 함수 : 지연(Delay)함수
하나 이상의 yield return 무조건 필요
yield return 문에서 지연 시간을 지정한다
시간(초)지연 : yield return new WaitForSecond(지연시간(초));

형식
IEnumerator 함수이름()
{
    //...
    yield return .. // 하나 이상의  yield return 무조건 필요
}

코루틴 함수 호출
StartCoroutine(코루틴함수이름); 


 */