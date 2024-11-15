using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector2 targetPos;

    public bool isLoop = true;

    [Header("Optional")]
    [SerializeField] private ActivatorController _activator;
    public bool NonStay = false;

    private bool _hasToMove;


    void Start()
    {
        transform.position = posA.position;
        targetPos = posB.position;

        if (_activator != null)
        {
            _activator.playerTriggered += Activate;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLoop)
        {
            if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;
            if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
        }
        else if (_hasToMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);

            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                _hasToMove = false;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (NonStay == false)
        {
            if (col.gameObject.tag == "Player")
            {
                Vector2 playerPositionX = new Vector2(col.transform.position.x, 0);
                Vector2 targetPositionX = new Vector2(targetPos.x, 0);
                col.transform.position = new Vector2(Vector2.MoveTowards(playerPositionX, targetPositionX, speed).x, col.transform.position.y);
            }
        }


    }
    private void Activate()
    {
        _hasToMove = true;
    }

    public void Reset_()
    {   
        _hasToMove = false;
        transform.position = posA.position;
    }  

    private void OnDestroy()
    {
        if (_activator != null)
        {
            _activator.playerTriggered -= Activate;
        }
    }
}