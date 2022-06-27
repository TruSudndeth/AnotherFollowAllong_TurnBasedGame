using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitchange;

    [SerializeField] private Unit selectedUnit;
    private Vector3 Position;
    private Collider Selection;

    private void awake()
    {
        if(Instance != null)
        {
            Debug.Log("There's more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
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
            { 
                selectedUnit = NewUnit;

                OnSelectedUnitchange?.Invoke(this, EventArgs.Empty);
                //if (OnSelectedUnitchange != null)
                //{
                //   OnSelectedUnitchange(this, EventArgs.Empty);
                //}
            }
        }

        public Unit GetSelectedUnit() 
        {
            return selectedUnit;
        }

}
