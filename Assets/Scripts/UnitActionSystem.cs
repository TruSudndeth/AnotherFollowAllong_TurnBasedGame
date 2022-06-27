using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;
    private Vector3 Position;
    private Collider Selection;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseWorld.MInput.primary))
        {
            MouseWorld.GetPosition(out Position, out Selection);
            
            if(Selection.CompareTag("MousePlane"))
                selectedUnit.Move(Position);
            if (Selection.CompareTag("Unit"))
                TrySwitchUnit();
        }

    }
        private void TrySwitchUnit()
        {
            //selectedUnit = Selection.GetComponent<Unit>(); // no null protection use TryGetComponent
            if (Selection.TryGetComponent<Unit>(out Unit NewUnit)) 
                selectedUnit = NewUnit;
        }

}
