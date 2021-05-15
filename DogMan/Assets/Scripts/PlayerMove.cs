using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        private Animator _animator;
    
        public float speedMove;
        public float shiftMove;
        public float jumpPower;

        private float gravity;
        private Vector3 moveVector;

        private CharacterController ch_controller;
        private void Start()
        {
            ch_controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            CharasterMove();
            GameGravity();
        }

        private void CharasterMove()
        {
            moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * speedMove;
            if (moveVector.x != 0)
            {
                _animator.Play("Run");
            }
            else
            {
                _animator.Play("Stay");
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveVector.x = Input.GetAxis("Horizontal") * shiftMove;
            }
            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        
            moveVector.y = gravity;
            ch_controller.Move(moveVector * Time.deltaTime);
        }

        private void GameGravity()
        {
        
            if (!ch_controller.isGrounded) gravity -= 20f * Time.deltaTime;
            else
            {
                gravity = -1f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded)
            {
                gravity = jumpPower;
            }
        
        }
     
    }
}
