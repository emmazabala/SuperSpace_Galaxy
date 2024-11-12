using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] Transform _Waypoint;
    public Rigidbody2D PlayerRigidbody;
    public SpriteRenderer PlayerSR;
    public Checkpoint Checkpoint; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerRigidbody.gravityScale = Checkpoint.gravity;
            Debug.Log($"gravity"+Checkpoint.gravity);
            PlayerSR.flipY = Checkpoint.flipY;
            Debug.Log($"flipY" + Checkpoint.flipY);
            other.transform.position = _Waypoint.position;
        }
    }
}
