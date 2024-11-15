using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] private PickUpsCount _Counter;
    public bool Countable = true;

    [Header("Optional")]
    public bool ReActivate = false;
    private MaxMovement max;
    private MovingPlatform MovingPlatform;

    private void Start()
    {
        max = GameObject.FindObjectOfType<MaxMovement>();
        MovingPlatform = GameObject.FindObjectOfType<MovingPlatform>();
        if (max != null)
        {
            
           if (Countable == false && ReActivate == true)
           {
                max.playerDeadTriggered += Activate;
                
           }
             
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        { 
            if(Countable == true)
            {
                _Counter.OnPickUp();
            }
            gameObject.SetActive(false);
        }
    }

    

    private void Activate()
    {
      MovingPlatform.Reset_();
      gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        if (max != null)
        {
            max.playerDeadTriggered -= Activate;
        }
    }
}
