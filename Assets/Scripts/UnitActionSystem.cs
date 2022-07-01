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

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("There's more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseWorld.MInput.primary))
        {
            MouseWorld.GetPosition(out Position, out Selection);
            
            if(Selection.CompareTag("MousePlane"))
                selectedUnit.GetComponent<MoveAction>().Move(Position); //SomeHow Cache this to avoid calls.
            if (Selection.CompareTag("Unit"))
                TrySwitchUnit();
        }

    }
        public void TrySwitchUnit()
        {
            if (Selection.TryGetComponent<Unit>(out Unit NewUnit))
            { 
                selectedUnit = NewUnit;
                OnSelectedUnitchange?.Invoke(this, EventArgs.Empty);
            }
        }

        public Unit GetSelectedUnit() 
        {
            return selectedUnit;
        }

}
