using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseWorld.MInput.primary))
        {
         selectedUnit.Move(MouseWorld.GetPosition());
        }
        
    }

}
