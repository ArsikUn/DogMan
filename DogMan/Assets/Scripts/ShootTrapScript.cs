using System;
using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Trap
{

    public class ShootTrapScript : MonoBehaviour
    {
        
        [SerializeField] private bool isRight = false;
        [SerializeField] private GameObject bullet;
        [Range(4,6)]
        [SerializeField] private float bulletSpeed = 1;
        [Range(0.2f,2)]
        [SerializeField] private float bulletRange = 1;
        

        private Vector3 bulletStartPos;
        public static Action<bool,float> right = delegate { };

        void OnEnable()
        {
            
            bulletStartPos = transform.GetChild(1).position;
            StartCoroutine(shoot());
        }

        IEnumerator shoot()
        {
            while (true)
            {
                Instantiate(bullet);
                right(isRight, bulletSpeed);
                bullet.transform.position = bulletStartPos;
                yield return new WaitForSeconds(bulletRange);
            }

        }

        
    }
}
   
