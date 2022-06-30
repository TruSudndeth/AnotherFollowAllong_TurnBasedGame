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
    [SerializeField] private float smoothZoomSpeed = 1.0f;
    [SerializeField] private bool inverted = false;
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

        CinemachineTransposer CMTransposer = CMVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        Vector3 followOffset = CMTransposer.m_FollowOffset;

        if(Input.mouseScrollDelta.y > 0)
        {
            followOffset.y -= zoomAmount * (inverted ? -1 : 1);
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            followOffset.y += zoomAmount * (inverted ? -1 : 1);
        }

        followOffset.y = Mathf.Clamp(followOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);
        Vector3 smoothZoom = followOffset;
        if(Mathf.Sqrt(followOffset.y - CMTransposer.m_FollowOffset.y) > 0.10f)
        {
            smoothZoom += followOffset * Time.deltaTime * smoothZoomSpeed;
        }
        
        CMTransposer.m_FollowOffset = smoothZoom;
    }
}
