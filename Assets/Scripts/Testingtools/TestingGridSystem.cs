using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGridSystem : MonoBehaviour
{
    [SerializeField] private Unit unit;

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
            GridSystemVisual.Instance.HideAllGridPositions();
            GridSystemVisual.Instance.ShowGridPositionList(unit.GetMoveAction().GetValidActionGridPositionList());
    }
}
