using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        private Animator _animator;
    
        public float speedMove;
        public float shiftMove;
        public float jumpPower;

        private Rigidbody rb;
        public bool isGround;
        public bool isWall;
        public bool isRoof;

        private float gravity;
        private Vector3 moveVector;

        private CharacterController ch_controller;
        private void Start()
        {
            ch_controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            CharasterMove();
            GameGravity();
            Jump();
            
        }

        private void CharasterMove()
        {
            moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Horizontal") * speedMove;
            
            if (moveVector.x != 0)
            {
                _animator.SetBool("Move", true);
            }
            else
            {
                _animator.SetBool("Move", false);
            }
            
            if (Input.GetKey(KeyCode.LeftControl))
            { 
                GetComponent<CharacterController>().height = 0.5f;
                GetComponent<CharacterController>().center = new Vector3(0.07f, 0.0f, 0.0f);
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    _animator.SetBool("StepSquat", true);
                }
                _animator.SetBool("Squat", true);
            }
            else
            {
                GetComponent<CharacterController>().height = 3.4f;
                GetComponent<CharacterController>().center = new Vector3(0.07f, 0.5f, 0.0f);
                _animator.SetBool("StepSquat", false);
                _animator.SetBool("Squat", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveVector.x = Input.GetAxis("Horizontal") * shiftMove;
                _animator.SetBool("Shift", true);
            }
            else
            {
                _animator.SetBool("Shift", false);
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
            if (!ch_controller.isGrounded)
            {
                gravity -= 30f*Time.deltaTime;
            }
            else
            {
                gravity = -1f;
            }
        }

        private void Jump()
        {
            Ray ray = new Ray(gameObject.transform.position, Vector3.left);
            Ray ray2 = new Ray(gameObject.transform.position, Vector3.right);
            Ray ray3 = new Ray(gameObject.transform.position, Vector3.down);
            Ray ray4 = new Ray(gameObject.transform.position, Vector3.up);
            Debug.DrawRay(transform.position, ray2.direction * 1f);
            Debug.DrawRay(transform.position, ray4.direction * 2f);
            Debug.DrawRay(transform.position, ray3.direction * 1f);
            Debug.DrawRay(transform.position, ray.direction * 1f);
            RaycastHit rh;
            if (Physics.Raycast(ray4, out rh, 1.5f))
            {
                isRoof = true;
            }
            else
            {
                isRoof = false;
            }

            if (isRoof == true)
            {
                gravity = -1f;
            }
            if (Physics.Raycast(ray3, out rh, 1.0f))
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }

            if (Physics.Raycast(ray, out rh, 0.9f) || Physics.Raycast(ray2, out rh, 0.9f))
            {
                gravity = -0.5f;
                isWall = true;
            }
            else
            {
                isWall = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround == true || Input.GetKeyDown(KeyCode.Space) &&  isWall == true)
            {
                gravity = jumpPower;
            }
        }


    }
}
