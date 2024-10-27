using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MaxMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce; 
    public Rigidbody2D Rbd;
    private SpriteRenderer _MaxSR;
    private float _Horizontal;
    
    void Start()
    {
         Rbd = GetComponent<Rigidbody2D>();
        _MaxSR = GetComponent<SpriteRenderer>();
    }

   private void Update()
    {
       
        

      /*  if(Input.GetKeyDown(KeyCode.W) && _InGround == true)
        {
            Jump();
            _InGround = false;
        }*/
    }

    private void Move()
    {
        _Horizontal = Input.GetAxisRaw("Horizontal");
        Rbd.velocity = _Horizontal * Speed * Vector2.right;
        if(_Horizontal > 0)
        {
            _MaxSR.flipX = false;
        }
        else if(_Horizontal < 0)
        {
            _MaxSR.flipX = true;
        }
    }

    /*private void Jump()
    {
        Rbd.AddForce(Vector2.up * JumpForce);
    }*/

    
    }
    
    
                    
}
