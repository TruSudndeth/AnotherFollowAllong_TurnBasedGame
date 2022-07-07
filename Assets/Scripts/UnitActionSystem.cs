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
    private bool isBusy;


    //Unit Max Distance set to 4 then quickly changed back to 1 continues to move 4 units FIX!
    private void Awake()
    {
        if (Instance != null)
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
        if (isBusy) return;

        if (Input.GetMouseButtonDown(MouseWorld.MInput.primary))
        {
            MouseWorld.GetPosition(out Position, out Selection);

            if (Selection.CompareTag("MousePlane"))
            {
                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(Position);
                if (selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPosition))
                {
                    selectedUnit.GetMoveAction().Move(mouseGridPosition, ClearBusy);
                    SetBusy();
                }
                //selectedUnit.GetMoveAction().Move(Position)
            }
            if (Selection.CompareTag("Unit"))
                TrySwitchUnit();

        }
        if(Input.GetMouseButtonDown(1))
        {
            SetBusy();
            selectedUnit.GetSpinAction().Spin(ClearBusy);
        }
    }
    private void SetBusy()
    {
        isBusy = true;
    }
    private void ClearBusy()
    {
        isBusy = false;
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
