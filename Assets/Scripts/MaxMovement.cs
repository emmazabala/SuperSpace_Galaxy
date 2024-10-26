using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce; 
    public Rigidbody2D Rbd;
    private SpriteRenderer _MaxSR;
    private float _Horizontal;
    private bool _InGround;
    void Start()
    {
         Rbd = GetComponent<Rigidbody2D>();
        _MaxSR = GetComponent<SpriteRenderer>();
    }

   private void Update()
    {
        

        
        if(Input.GetKeyDown(KeyCode.W) && _InGround == true)
        {
            Jump();
            _InGround = false;
        }
    }

    private void Move ()
    {
        _Horizontal = Input.GetAxisRaw("Horizontal");
        Rbd.velocity = new Vector2(_Horizontal * Speed, Rbd.velocity.y);
        if(_Horizontal > 0)
        {
            _MaxSR.flipX = false;
        }
        else if(_Horizontal < 0)
        {
            _MaxSR.flipX = true;
        }
    }

    private void Jump()
    {
        Rbd.AddForce(Vector2.up * JumpForce);
    }

    public void OnCollisionEnter2D(Collision2D ground)
    {
        Debug.Log("toque algo");
        
        if(ground.gameObject.tag == "Suelo")
        {
            Debug.Log("toque suelo");
            _InGround = true;
        }
        else
        {
            _InGround = false;
        }
    }

    private void GravityChange()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }


    }
                    
}
