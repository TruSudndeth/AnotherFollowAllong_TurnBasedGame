using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float stoppingDistance = 0.1f;

    private GridPosition gridPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }


    void Update()
    {
        if((targetPosition - transform.position).sqrMagnitude > stoppingDistance) //magic numbers 1f was used replace with variable
        {
            var moveDirection = targetPosition - transform.position;
            transform.position += moveDirection.normalized * Time.deltaTime * moveSpeed; // moveSpeed will overshoot the distance 1f in if condition
            if(!unitAnimator.GetBool("IsWalking")) unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
           if(unitAnimator.GetBool("IsWalking")) unitAnimator.SetBool("IsWalking", false);
        }
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition; //update current Position
        }
    }
    public void Move(Vector3 _targetPosition)
    {
        targetPosition = _targetPosition;
    }
}
