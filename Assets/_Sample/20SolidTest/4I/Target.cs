using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 전투 가능한 유닛: 
    /// </summary>
    public class Target : Health, IDamagable
    {
        public void TakeDamage(float damage)
        { 
            throw new System.NotImplementedException();
        }
    }
}