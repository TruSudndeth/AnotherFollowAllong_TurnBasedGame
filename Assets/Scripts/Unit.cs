using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Vector3 SetTarget;
    private Vector3 targetPosition = Vector3.zero; 
    [SerializeField]
    private float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        SetTarget = new Vector3(4,0,4);
    }
    // Update is called once per frame
    void Update()
    {
        if((targetPosition - transform.position).sqrMagnitude > 1f)
        {
            Debug.Log("this code Stops");  //delete code
            var moveDirection = targetPosition - transform.position;
            transform.position += moveDirection.normalized * Time.deltaTime * moveSpeed; // moveSpeed will overshoot the distance 1f in if condition
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            Move(SetTarget);
        }
    }
    private void Move(Vector3 _targetPosition)
    {
        targetPosition = _targetPosition;
    }
}
