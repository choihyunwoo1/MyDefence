using UnityEngine;

namespace Sample
{
    public class FrontMove : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            /* this.transform.Translate(new Vector3(3, 0, 0)); */
            //의자를 이동하라
            Debug.Log("앞으로 이동한다");
        }
    }
}