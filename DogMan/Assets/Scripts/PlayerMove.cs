using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
       [SerializeField]
       private float speed = 6f;

       [SerializeField]
       private Rigidbody physicsBody = null;
       
       [SerializeField] 
       private Transform groundCheck;

       [SerializeField]
       private Vector3 _movement;

       public bool isGround ;

       private void Update()
       {
              if (Physics2D.Linecast(transform.position,
                     groundCheck.position,
                     1 << LayerMask.NameToLayer("Ground")))

              {
                     isGround = true;
              }
              else
              {
                     isGround = false;
              }

              float inputY = 0;
              if (Input.GetKey(KeyCode.Space)&& isGround==true)
              {
                            inputY = 1;
              }
              
              else if (Input.GetKey(KeyCode.DownArrow))
              {
                     inputY = -1;
              }
              float inputX = 0;
              if ( Input.GetKey(KeyCode.RightArrow) )
              {
                     inputX = 1;
              }
              else if (Input.GetKey(KeyCode.LeftArrow))
              {
                     inputX = -1;
              }

              _movement = new Vector3(inputX, inputY, 0).normalized;

       }

       private void FixedUpdate ()
       {
              physicsBody.velocity = _movement * speed;
       }
}
