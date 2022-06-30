using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private const float MIN_FOLLOW_Y_OFFSET = 2.0f;
    private const float MAX_FOLLOW_Y_OFFSET = 12.0f;

    [SerializeField] private CinemachineVirtualCamera CMVirtualCamera;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotateSpeed = 100.0f;
    [SerializeField] private float zoomAmount = 1.0f;
    [SerializeField] private float smoothZoomSpeed = 5.0f;
    [SerializeField] private bool inverted = false;

    private CinemachineTransposer CMTransposer; // cached $$$
    private Vector3 targetFollowOffset;

    private void Start()
    {
        CMTransposer = CMVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = CMTransposer.m_FollowOffset;
    }
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

        

        targetFollowOffset = CMTransposer.m_FollowOffset;

        if(Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmount * (inverted ? -1 : 1);
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmount * (inverted ? -1 : 1);
        }

        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);
        CMTransposer.m_FollowOffset = Vector3.Lerp(CMTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * smoothZoomSpeed);
    }
}
