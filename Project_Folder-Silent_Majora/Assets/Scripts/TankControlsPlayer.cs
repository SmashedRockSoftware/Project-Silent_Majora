using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TankControlsPlayer : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] float runSpeed = 4.0f;
    [SerializeField] float rotationSpeed = 180.0f;
    [SerializeField] float gravity = 20.0f;
    CharacterController characterController;

    [SerializeField] bool canRun = true;
    [SerializeField] bool getsTired = true;
    [SerializeField] float stamina = 10f;
    float maxStamina = 10f;

    private Vector3 moveDirection = Vector3.zero;

    [SerializeField] KeyCode runKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        maxStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded) {
            float _speed = speed;
            if (canRun && stamina > 0 && Input.GetKey(runKey)) {
                _speed = runSpeed;
                if (getsTired && characterController.velocity.magnitude > 0) stamina -= Time.deltaTime;
            }

            if (stamina < maxStamina && (!Input.GetKey(runKey) || characterController.velocity.magnitude < 0.1f)) stamina += Time.deltaTime;

            moveDirection = transform.forward * Input.GetAxis("Vertical");
            moveDirection *= _speed;

            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * 2f);
    }
}
