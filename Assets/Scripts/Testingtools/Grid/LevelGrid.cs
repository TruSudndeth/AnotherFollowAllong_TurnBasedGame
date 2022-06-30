using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;

    private Collider Unit;
    private Vector3 worldPosition;


    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    private void Update()
    {
        // This Showed where the mouse was Passivly 
        //MouseWorld.GetPosition(out worldPosition, out Unit);
        //Debug.Log(gridSystem.GetGridPosition(worldPosition));
    }

    public void SetUnitAtGridPosition(GridPosition _gridPosition, Unit _unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(_gridPosition);
        gridObject.Unit = _unit;
    }
    public Unit GetUnitAtGridPosition(GridPosition _gridPosition) // retur Unit
    {
        GridObject gridObject = gridSystem.GetGridObject(_gridPosition);
        return gridObject.Unit;
    }
    public void ClearUnitAtGridPosition(GridPosition _gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(_gridPosition);
        gridObject.Unit = null;
    }

    public void UnitMovedGridPosition(Unit _unit, GridPosition _fromGridPosition, GridPosition _toGridPosition)
    {
        ClearUnitAtGridPosition(_fromGridPosition);

        SetUnitAtGridPosition(_toGridPosition, _unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
}
