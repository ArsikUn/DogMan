using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Trap
{
    public class BulletScript : MonoBehaviour
    {
        public bool right = false;
        private int _moveRight = 1;
        public float bulletSpeed;

        public static Action damege = delegate { };


        void Start()
        {
            if (!right)
            {
                _moveRight = -1;
            }
        }


        void Update()
        {
            transform.Translate(Vector3.right * 0.01f * _moveRight * bulletSpeed);

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "player")
            {
                damege();
            }

            Destroy(gameObject);


        }

    }
}
