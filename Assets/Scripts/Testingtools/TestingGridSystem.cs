using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridSystem : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private GridSystemVisual GSV;

    private GridPosition lastGridPosition;

    private void Start()
    {
        
        lastGridPosition = unit.GetGridPosition();
        ShowGridPositionList();
    }

    private void Update()
    {
        if (unit.GetGridPosition() != lastGridPosition)
        {
            lastGridPosition = unit.GetGridPosition();
            ShowGridPositionList();
        }

    }

    public void ShowGridPositionList()
    {
            GSV.HideAllGridPositions();
            GSV.ShowGridPositionList(unit.GetMoveAction().GetValidActionGridPositionList());
    }
}
