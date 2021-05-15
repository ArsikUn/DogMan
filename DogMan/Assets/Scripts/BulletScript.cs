using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Trap
{
    public class BulletScript : MonoBehaviour
    {
        private bool right = false;
        private int _moveRight = 1;
        private float bulletSpeed;

        public static Action death = delegate { };

        void OnEnable()
        {
            ShootTrapScript.right += ShootTrapScript_Right;
        }

        private void ShootTrapScript_Right(bool right, float bulletSpeed)
        {
            this.bulletSpeed = bulletSpeed;
            if (!right)
            {
                _moveRight = -1;
            }
        }

        void Update()
        {
            transform.Translate(Vector3.right * 0.01f* _moveRight* bulletSpeed);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("F");
            if (other.gameObject.tag == "player")
            {
                death();
            }
            else
            {
                Destroy(gameObject);
            }

        }

        void OnDisable()
        {
            ShootTrapScript.right -= ShootTrapScript_Right;
        }
    }
}
