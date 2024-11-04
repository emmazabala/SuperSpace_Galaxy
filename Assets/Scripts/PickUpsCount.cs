using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsCount : MonoBehaviour
{
    [SerializeField] private int _TotalPickUps;
    private int _PickUpsCount = 0;
    
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
