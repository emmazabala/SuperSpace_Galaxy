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
    public Animator Animator;
    private float _Horizontal;
    public LayerMask groundLayer;
    public LayerMask ceilLayer;
    public Vector2 boxSize;
    public float castDistance = 0.18f;
    private bool _InGround;
    private bool _InCeil;
    private string ActualAnimation;
    private bool _IsMoving = false;

    const string idle = "Idle";
    const string RunLeft = "RunLeft";
    const string RunRigth = "RunRigth";
    void Start()
    {
         Rbd = GetComponent<Rigidbody2D>();
        _MaxSR = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        Rbd.gravityScale = 10;
        Speed = 2;
    }

   private void Update()
    {
        
        

        if (_IsMoving == false)
        {
            ChangeAnimationState(idle);
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
        if(_Horizontal != 0)
        {
            _IsMoving = true;
        }
        else 
        {
            _IsMoving = false;  
        }
            if (_Horizontal > 0 && _IsMoving == false)
            {
             _MaxSR.flipX = false;
            }
            else if(_Horizontal < 0 && _IsMoving == false)
            {
                _MaxSR.flipX = true;
            }
            if(_Horizontal > 0 && _IsMoving == true)
            {
                
                ChangeAnimationState(RunRigth);
            }
           
            else if(_Horizontal < 0 && _IsMoving == true)
            {
                
                ChangeAnimationState(RunLeft);
            }
            
            
    }

    private void GravityChange()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, castDistance, groundLayer))
        {
           
            _InGround = true;
            
        }
       else if (Physics2D.Raycast(transform.position, Vector2.up, castDistance, ceilLayer))
        {
            
            _InCeil = true;
            
        }
        else
        {
            _InGround = false;
            _InCeil = false;
        }


        if (_InGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _IsMoving = true ;
                Rbd.gravityScale *= -1;
                _MaxSR.flipY = !_MaxSR.flipY;
            }

        }
        else if (_InCeil == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _IsMoving = true;
                Rbd.gravityScale *= -1;
                _MaxSR.flipY = !_MaxSR.flipY;
            }
        }
        else
        {
            _InCeil = false;
            _InGround = false;
            return;
        }

    }

    void ChangeAnimationState(string newAnimation)
    {
        if(ActualAnimation == newAnimation)
        { return; }
        Animator.Play(newAnimation);
        ActualAnimation = newAnimation;
    }
    /*private void Jump()
    {
        Rbd.AddForce(Vector2.up * JumpForce);
    }*/


}
