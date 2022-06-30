using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private Unit unit;

    public GridObject(GridSystem _gridSystem, GridPosition _gridPosition)
    {
        gridSystem = _gridSystem;
        gridPosition = _gridPosition;
    }

    public Unit Unit
    {
        get{ return unit; }
        set { unit = value; }
    }

    public override string ToString()
    {
        string returns = unit != null ? gridPosition.ToString() + Environment.NewLine + unit.name : gridPosition.ToString();
        return returns;
    }
}