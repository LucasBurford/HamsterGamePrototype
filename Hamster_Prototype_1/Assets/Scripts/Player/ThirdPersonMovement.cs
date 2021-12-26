using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Fields

    #region References
    [Header("References")]
    public Rigidbody rb;
    public CharacterController controller;
    #endregion

    #region Gameplay and spec
    [Header("Gameplay and spec")]

    public float moveSpeed;   
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
        // Get input
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(xInput, 0, zInput);
        movementDirection.Normalize();

        controller.Move(movementDirection * moveSpeed);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
