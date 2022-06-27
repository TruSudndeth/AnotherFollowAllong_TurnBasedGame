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
            Vector3 Position;
            Collider Selection;
            MouseWorld.GetPosition(out Position, out Selection);
            if(Selection.CompareTag("MousePlane"))
                selectedUnit.Move(Position);
            if (Selection.CompareTag("Unit"))
                selectedUnit = Selection.GetComponent<Unit>();
        }
        
    }

}
