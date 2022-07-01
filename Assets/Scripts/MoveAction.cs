using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float stoppingDistance = 0.1f;

    private Vector3 targetPosition;


    private void Awake()
    {
        targetPosition = transform.position;
    }
    void Start()
    {
        
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
    public void Move(Vector3 _targetPosition)
    {
        targetPosition = _targetPosition;
    }
}
