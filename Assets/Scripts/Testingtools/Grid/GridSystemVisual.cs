using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    public static GridSystemVisual Instance { get; private set; }

    [SerializeField] private Transform gridVisualObj;

    private GridVisualSingle[,] gridSystemVisualSingleArray;
    private Unit unit;
    private GridPosition lastGridPosition;
    void Awake()
    {
        unit = UnitActionSystem.Instance.GetSelectedUnit();
        lastGridPosition = unit.GetGridPosition();

        if (Instance != null)
        {
            Debug.Log("There's more than one GridSystemVisual! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystemVisualSingleArray = new GridVisualSingle[LevelGrid.Instance.GetWidth(),LevelGrid.Instance.GetHeight()];
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform gridVisualSingleTransform = Instantiate(gridVisualObj, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
                gridSystemVisualSingleArray[x, z] = gridVisualSingleTransform.GetComponent<GridVisualSingle>();
            }
        }
    }

    private void Update()
    {
        if (unit.GetGridPosition() != lastGridPosition || unit != UnitActionSystem.Instance.GetSelectedUnit())
        {
            UpdateGridVisuals();
            lastGridPosition = unit.GetGridPosition();
        }
}

public void HideAllGridPositions()
    {
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                gridSystemVisualSingleArray[x, z].Hide();
            }
        }
    }
    public void ShowGridPositionList(List<GridPosition> _gridPositions)
    {
        foreach(GridPosition gridP in _gridPositions)
        {
            gridSystemVisualSingleArray[gridP.x, gridP.z].Show();
        }
    }

    public void UpdateGridVisuals()
    {
        unit = UnitActionSystem.Instance.GetSelectedUnit();
        HideAllGridPositions();
        ShowGridPositionList(unit.GetMoveAction().GetValidActionGridPositionList());
    }
}
