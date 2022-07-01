using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float stoppingDistance = 0.1f;
    [SerializeField] private int maxMoveDistance = 4;

    private Unit unit;
    private Vector3 targetPosition;


    private void Awake()
    {
        unit = GetComponent<Unit>();
        targetPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if ((targetPosition - transform.position).sqrMagnitude > stoppingDistance) //magic numbers 1f was used replace with variable
        {
            var moveDirection = targetPosition - transform.position;
            transform.position += moveDirection.normalized * Time.deltaTime * moveSpeed; // moveSpeed will overshoot the distance 1f in if condition
            if (!unitAnimator.GetBool("IsWalking")) unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            if (unitAnimator.GetBool("IsWalking")) unitAnimator.SetBool("IsWalking", false);
        }
    }
    public void Move(GridPosition _targetPosition)
    {
        targetPosition = LevelGrid.Instance.GetWorldPosition(_targetPosition);
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition)) continue;
                if (unitGridPosition == testGridPosition) continue; // same testPosition as the Unit (Standing)
                if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition)) continue; //Grid position already occupied with another unit
                //Debug.Log(testGridPosition);
                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}
