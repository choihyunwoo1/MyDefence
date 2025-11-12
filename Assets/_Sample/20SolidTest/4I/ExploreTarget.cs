using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 전투 가능, 죽을시 폭발하는 유닛
    /// </summary>
    public class ExploreTarget : Target, IExploreable
    {
        protected override void Die()
        {
            base.Die();

            ExPlore();
        }

        public void ExPlore()
        { 
            throw new System.NotImplementedException();
        }
    }
}