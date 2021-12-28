using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    #region Fields
    #region References
    [Header("Referecnes")]

    // Layer mask
    public LayerMask layerMask;

    // Origin of player vision (the camera)
    public Transform visionOrigin;

    // Reference to interact with object text
    public TMP_Text interactText;

    [Header("Party members")]
    // Reference to Hedgehog script
    public Hedgehog hedgehog;
    #endregion

    #region Gameplay and spec
    [Header("Floats and ints")]
    // Distance the player can see
    public float visionDistance;

    // Bool to determine if player has issued a command
    public bool hasIssuedACommand;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InteractionVision();
    }

    private void InteractionVision()
    {
        RaycastHit seenObject;
        Ray visionRay = new Ray(visionOrigin.position, Vector3.forward);

        if (Physics.Raycast(visionRay, out seenObject, visionDistance))
        {
            // If player is looking at a smashable obstacle
            if (seenObject.collider.gameObject.CompareTag("SmashableWall"))
            {
                // Display interact with text only if player hasn't yet issued a command
                if (!hasIssuedACommand)
                {
                    interactText.gameObject.SetActive(true);
                }

                // Set the text
                interactText.text = "Smash wall";

                // If player then presses E to command it
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Set hasIssuedACommand to true
                    hasIssuedACommand = true;

                    // Store the obstacle
                    GameObject seenObj = seenObject.collider.gameObject;

                    // Call SmashObstacle in Hedgehog class and pass in the seen object
                    hedgehog.SmashObstacle(seenObj);

                    // Remove the text
                    interactText.gameObject.SetActive(false);
                }

            }
            print(seenObject.collider.gameObject.name);
        }
        else
        {
            interactText.gameObject.SetActive(false);
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * visionDistance;
        Gizmos.DrawRay(transform.position, direction);
    }
}
