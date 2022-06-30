using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;

    public GridObject(GridSystem _gridSystem, GridPosition _gridPosition)
    {
        gridSystem = _gridSystem;
        gridPosition = _gridPosition;
    }

    public override string ToString()
    {
        return gridPosition.ToString();
    }
}