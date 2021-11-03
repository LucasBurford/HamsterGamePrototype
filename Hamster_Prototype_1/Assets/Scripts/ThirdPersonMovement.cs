using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Members
    public GameObject playerCharacter;
    public CharacterController controller;
    public Transform cam;

    [SerializeField]
    private float speed = 6f;

    [SerializeField]
    private float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    [SerializeField]
    private bool hasJumped;
    #endregion

    // Update is called once per frame
    void Update()
    {
        #region Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.SimpleMove(moveDir.normalized * speed * Time.deltaTime);
        }
        #endregion

        CheckInputs();
    }

    private void CheckInputs()
    {
        // When space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call Jump() if player is on the ground
            if (!hasJumped)
            {
                Jump();
            }
            // Set hasJumped to true to preven floating up on hold
            hasJumped = true;
        }
    }

    private void Jump()
    {
        // Move player up
        playerCharacter.transform.position = new Vector3(playerCharacter.transform.position.x, playerCharacter.transform.position.y + 2, playerCharacter.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player collides with the ground
        if (collision.gameObject.GetComponent<Terrain>())
        {
            hasJumped = false;
        }
    }
}
