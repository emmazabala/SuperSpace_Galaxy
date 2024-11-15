using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform Transform;
    public int gravity ;
    public bool flipY ;

    [SerializeField] void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("el chek trigger con player");
            GameObject obj = GameObject.Find("Checkpoint_");
            if (obj != null)
            {
                obj.GetComponent<Checkpoint>().gravity = gravity;
                obj.GetComponent<Checkpoint>().flipY = flipY;
                obj.transform.position = Transform.position;
            }
        }
    }
}

