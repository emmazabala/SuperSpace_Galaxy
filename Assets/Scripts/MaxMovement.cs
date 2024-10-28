using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MaxMovement : MonoBehaviour
{
    public float Speed = 2;
    public float JumpForce; 
    public Rigidbody2D Rbd;
    public SpriteRenderer _MaxSR;
    private float _Horizontal;
    public LayerMask groundLayer;
    public LayerMask ceilLayer;
    public Vector2 boxSize;
    public float castDistance = 0.18f;
    private bool _InGround;
    private bool _InCeil;
    void Start()
    {
         Rbd = GetComponent<Rigidbody2D>();
        _MaxSR = GetComponent<SpriteRenderer>();
        Rbd.gravityScale = 10;
        Speed = 2;
    }

   private void Update()
    {
        
        if (Physics2D.Raycast(transform.position, Vector2.down, castDistance, groundLayer))
        {
            Debug.Log("toque suelo");
            _InGround = true;
        }
         else if (Physics2D.Raycast(transform.position, Vector2.up, castDistance, ceilLayer))
        {
            Debug.Log("toque techo");
            _InCeil = true;
        }
        else 
        {
            Debug.Log("volando");
            _InGround = false;
            _InCeil = false;    
        }
        GravityChange();
        Move();

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

    private void GravityChange()
    {
        if (_InGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rbd.gravityScale *= -1;
                _MaxSR.flipY = !_MaxSR.flipY;
            }

        }
        else if (_InCeil == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rbd.gravityScale *= -1;
                _MaxSR.flipY = !_MaxSR.flipY;
            }
        }
        else
        {
            _InGround = false;
            _InCeil = false;
            return;
        }

    }

    /*private void Jump()
    {
        Rbd.AddForce(Vector2.up * JumpForce);
    }*/


}
    
    
                    

