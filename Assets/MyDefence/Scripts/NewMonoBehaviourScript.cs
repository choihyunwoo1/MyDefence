using UnityEngine;

namespace MyDefence
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {
        public Vector3 position;

        public void NewPosition()
        {
            this.transform.position = new Vector3(transform.position.x, position.y, transform.position.z);
        }
    }
}