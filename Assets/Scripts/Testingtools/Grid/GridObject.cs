using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridObject(GridSystem _gridSystem, GridPosition _gridPosition)
    {
        gridSystem = _gridSystem;
        gridPosition = _gridPosition;
        unitList = new List<Unit>();
    }

    public void AddUnit(Unit _unit)
    {
        unitList.Add(_unit);
    }

    public void RemoveUnit(Unit _unit)
    {
        unitList.Remove(_unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public override string ToString()
    {

        string returnUnits = "";
        foreach(Unit _unit in unitList)
        {
            returnUnits += _unit.name + "\n";
        }

        return gridPosition.ToString() + "\n" + returnUnits;
    }
}