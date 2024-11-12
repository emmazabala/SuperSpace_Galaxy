using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsCount : MonoBehaviour
{
    private int _TotalPickUps;
    private int _PickUpsCount = 0;
    private void Start()
    {
       _TotalPickUps  = transform.parent.childCount - 1;
        Debug.Log($"Total de pickups= " +  _TotalPickUps);
        gameObject.SetActive(false);
       
    }
    public void OnPickUp ()
    {
        Debug.Log("Tamo activo");
        _PickUpsCount++;
        if ( _PickUpsCount == _TotalPickUps )
        {
            gameObject.SetActive(true);
        }
    }
    
}
