using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 미사일 발사체를 관리하는 클래스
    /// </summary>
    public class Rocket : Bullet
    {
        #region Variables
        //거리안에 있는 적에게 데미지 주는 범위
        public float damageRange = 3.5f;
        #endregion

        private void OnDrawGizmosSelected()
        {
            //타워중심에 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }
        #region Custom Method
        protected override void HitTarget()
        {
            //타격위치에 이펙트를 생성(Instiate)한 후 3초뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(impactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //damageRange안에 있는 모든 적에게 데미지
            Explosion();

            //탄환 킬
            Destroy(this.gameObject);
        }

        //damageRange안에 있는 모든 적에게 데미지 부여하는 함수
        private void Explosion()
        {
            //데미지 범위안에 있는 모든 충돌체 가져오기
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);

            //모든 충돌체 중에서 enemy 찾기
            foreach (Collider collider in hitColliders)
            {
                // Enemy라는 태그를 가진 적 오브젝트만 공격
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }

        #endregion
    }
}