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
    public Transform PlayerTransform;
    private float _Horizontal;
    public LayerMask groundLayer;
    public Vector2 boxSize;
    public float castDistance = 0.18f;
    private bool _InGround;
    private string ActualAnimation;
    private bool _IsMoving = false;
    public Checkpoint Checkpoint;
    public Transform _RespawnWaypoint;
    

    const string idle = "Idle";
    const string RunLeft = "RunLeft";
    const string RunRigth = "RunRigth";

    public PlayerDeadTriggered playerDeadTriggered;
    public delegate void PlayerDeadTriggered();
    void Start()
    {
         Rbd = GetComponent<Rigidbody2D>();
        _MaxSR = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        PlayerTransform = GetComponent<Transform>();
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
        else if (Physics2D.Raycast(transform.position, Vector2.up, castDistance, groundLayer))
        {

            _InGround = true;

        }
        else
        {
            _InGround = false;
        }

        if (_InGround == true)
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
    
    public void Kill()
    {
        Rbd.gravityScale = Checkpoint.gravity;
        _MaxSR.flipY = Checkpoint.flipY;
        PlayerTransform.position = _RespawnWaypoint.transform.position;
        playerDeadTriggered?.Invoke();
    }
}
