using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class GravityControl : MonoBehaviour
{
    private Rigidbody2D Rbd;
    private SpriteRenderer _MaxSR;
    private bool _InGround;
    private bool _InCeil;

    void Start()
    {
        Rbd = GetComponent<Rigidbody2D>();
        _MaxSR = GetComponent<SpriteRenderer>(); 
    }

    
    void Update()
    {
        GravityChange();  
    }

    private void GravityChange()
    {
        if (_InGround == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Rbd.gravityScale *= -1;
                _MaxSR.flipY = !_MaxSR.flipY;
            }
            
        }
        else if(_InCeil == true) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rbd.gravityScale *= -1;
                _MaxSR.flipY = !_MaxSR.flipY;
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D ground)
        {
            Debug.Log("toque algo");

            if (ground.gameObject.tag == "Suelo")
            {
                Debug.Log("toque suelo");
                _InGround = true;
            }
            else
            {
                _InGround = false;
            }

            if (ground.gameObject.tag == "Techo")
            {
                Debug.Log("toque techo");
                _InCeil = true;
            }
            else
            {
                _InCeil = false;
            }
    }
}

