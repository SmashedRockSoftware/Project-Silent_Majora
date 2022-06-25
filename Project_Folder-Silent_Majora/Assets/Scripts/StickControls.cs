using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControls : MonoBehaviour {
    [SerializeField] float speed = 6.0f;
    [SerializeField] float rotationSpeed = 6.0f;
    [SerializeField] float gravity = 20.0f;
    CharacterController characterController;

    Camera mainCamera;

    private Vector3 moveDirection = Vector3.zero;

    Vector3 moveForward, moveRight;
    Vector3 zeroYMoveDir;
    Vector3 lastCamPos;

    // Start is called before the first frame update
    void Start() {
        characterController = GetComponent<CharacterController>();

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if ((lastCamPos != mainCamera.transform.position) && (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)) {
            moveForward = mainCamera.transform.forward;
            moveRight = mainCamera.transform.right;
        }

        if (characterController.isGrounded) {
            moveDirection = moveForward * Input.GetAxis("Vertical");
            moveDirection *= speed;

            moveDirection += moveRight * Input.GetAxis("Horizontal");
            moveDirection *= speed;

            moveDirection.y = 0;

            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
            //zeroYMoveDir = transform.position + new Vector3(moveDirection.x, 0, moveDirection.z);
            //transform.LookAt(zeroYMoveDir);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + moveForward, transform.position + moveForward * 2f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + moveRight, transform.position + moveRight * 2f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position + zeroYMoveDir, transform.position + zeroYMoveDir * moveDirection.magnitude);
    }
}
