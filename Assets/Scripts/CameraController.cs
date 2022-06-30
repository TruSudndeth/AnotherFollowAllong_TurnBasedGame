using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotateSpeed = 100.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 inputMoveDir = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;

        Vector3 rotateVector = Vector3.zero;

        if(Input.GetKey(KeyCode.Q))
        {
            rotateVector.y += +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotateVector.y += -1;
        }

        transform.eulerAngles += rotateVector * rotateSpeed * Time.deltaTime;
    }
}
