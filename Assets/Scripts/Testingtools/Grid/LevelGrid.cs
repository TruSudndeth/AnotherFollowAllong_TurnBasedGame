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

    public void AddUnitAtGridPosition(GridPosition _gridPosition, Unit _unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(_gridPosition);
        gridObject.AddUnit(_unit);
    }
    public List<Unit> GetUnitListAtGridPosition(GridPosition _gridPosition) // retur Unit
    {
        GridObject gridObject = gridSystem.GetGridObject(_gridPosition);
        return gridObject.GetUnitList();
    }
    public void RemoveUnitAtGridPosition(GridPosition _gridPosition, Unit _unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(_gridPosition);
        gridObject.RemoveUnit(_unit);
    }

    public void UnitMovedGridPosition(Unit _unit, GridPosition _fromGridPosition, GridPosition _toGridPosition)
    {
        RemoveUnitAtGridPosition(_fromGridPosition, _unit);

        AddUnitAtGridPosition(_toGridPosition, _unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public int GetWidth() => gridSystem.GetWidth();
    public int GetHeight() => gridSystem.GetHeight();

    public bool HasAnyUnitOnGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.HasAnyUnit();
    }
}
