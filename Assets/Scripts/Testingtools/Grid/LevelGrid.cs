using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;

    private Collider Unit;
    private Vector3 worldPosition;
    // Start is called before the first frame update
    void Awake()
    {
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    private void Update()
    {
        MouseWorld.GetPosition(out worldPosition, out Unit);
        Debug.Log(gridSystem.GetGridPosition(worldPosition));
    }

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {

    }
    public Unit GetUnitAtGripPosition(GridPosition gridPosition)
    {

    }
    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {

    }
}
