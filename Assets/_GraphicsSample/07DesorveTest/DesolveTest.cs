using UnityEngine;
using System.Collections;

namespace Sample
{
    public class DesolveTest : MonoBehaviour
    {
        #region Variables
        public Renderer Renderer; //material

        Material originMaterial; //original
        public Material desolveMaterial; //desolve
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            originMaterial = Renderer.material; //original 저장

            //디졸브 이펙트 플레이
            StartCoroutine(SpawnEllen());
        }
        #endregion

        #region Custom Method

        IEnumerator SpawnEllen()
        {
            Renderer.material = desolveMaterial; 
            Renderer.material.SetFloat("_SplitValue", 0f);

            yield return new WaitForSeconds(0.5f);

            float t = 0f;

            while (t < 1.5f)
            {
                t += Time.deltaTime;
                float value = t / 1.5f;

                Renderer.material.SetFloat("_SplitValue", value);

                yield return null;
            }
            Renderer.material = originMaterial;
        }

        #endregion 
    }
}