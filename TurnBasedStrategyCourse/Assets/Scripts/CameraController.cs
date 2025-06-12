using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private const float MIN_FLOLLOW_Y_OFFSET = 2f; // Minimum follow y offset;
    private const float MAX_FLOLLOW_Y_OFFSET = 12f; // Maximum follow y offset;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera; // Reference to the virtual camera;

    private CinemachineTransposer cinemachineTransposer; // Reference to the transposer component;
    private Vector3 TargetFollowOffset; // Target follow offset;

    private void Start() // Start is called before the first frame update;
    {
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>(); // Get the transposer component;
        TargetFollowOffset = cinemachineTransposer.m_FollowOffset; // Get the follow offset;
    }


    private void Update() // Update is called once per frame;
    {        
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0,0,0); // Get the input move direction;
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f; // Move forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f; // Move backward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f; // Move left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f; // Move right;
        }

        float moveSpeed = 10f; // Move speed;

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x; // Calculate the move vector;
        transform.position += inputMoveDir * moveSpeed * Time.deltaTime; // Move the camera;
    }

    private void HandleRotation()
    {
        Vector3 rotationVector = new Vector3(0,0,0); // Get the input rotation direction;
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f; // Rotate left;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f; // Rotate right;
        }
        float rotationSpeed = 150f; // Rotation speed;

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime; // Rotate the camera;
        
    }

    private void HandleZoom()
    {
        float zoomAmount = 1f; // Zoom amount;

        if (Input.mouseScrollDelta.y > 0) // If the mouse wheel is scrolled up;
        {
            TargetFollowOffset.y -= zoomAmount; // Zoom out;
        }
        if (Input.mouseScrollDelta.y < 0) // If the mouse wheel is scrolled down;
        {
            TargetFollowOffset.y += zoomAmount; // Zoom in;
        }
        TargetFollowOffset.y = Mathf.Clamp(TargetFollowOffset.y, MIN_FLOLLOW_Y_OFFSET, MAX_FLOLLOW_Y_OFFSET); // Clamp the follow offset;
        float zoomspeed = 5f; // Zoom speed;
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, TargetFollowOffset, Time.deltaTime * zoomspeed); // Lerp the follow offset;
        
    }

}
