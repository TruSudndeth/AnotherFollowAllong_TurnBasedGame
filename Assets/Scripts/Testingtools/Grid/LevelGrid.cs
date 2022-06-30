using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;

    private Collider Unit;
    private Vector3 worldPosition;


    void Awake()
    {
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    private void Update()
    {
        // This Showed where the mouse was Passivly 
        //MouseWorld.GetPosition(out worldPosition, out Unit);
        //Debug.Log(gridSystem.GetGridPosition(worldPosition));
    }

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit _unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.Unit = _unit;
    }
    public Unit GetUnitAtGridPosition(GridPosition gridPosition) // retur Unit
    {
        return null;
    }
    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {

    }
}
