using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]
    public Rigidbody rb;
    public CharacterController controller;
    public Camera cam;
    #endregion

    #region Gameplay and spec
    [Header("Gameplay and spec")]

    // Speed at which the player actually moves
    public float moveSpeed;
    // The player's non-sprinting move speed
    public float regularSpeed;
    // the player's sprinting speed
    public float sprintSpeed;

    public float rotationSpeed;

    public bool isSprinting;
    public bool canMove;
    #endregion
    #endregion

    // Start is called once per frame
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        // Get input
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        Vector3 movementDirection = new Vector3(xInput, 0, zInput);
        movementDirection.Normalize();

        controller.Move(movementDirection * moveSpeed);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        #endregion

        if (isSprinting)
        {
            moveSpeed = sprintSpeed;

            
        }
        else
        {
            moveSpeed = regularSpeed;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
