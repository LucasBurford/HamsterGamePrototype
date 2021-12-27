using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    #region Fields
    [Header("Referecnes")]

    // Layer mask
    public LayerMask layerMask;

    // Origin of player vision (the camera)
    public Transform visionOrigin;

    [Header("Floats and ints")]
    // Distance the player can see
    public float visionDistance;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit seenObject;
        Ray visionRay = new Ray(visionOrigin.position, Vector3.forward);

        if (Physics.Raycast(visionRay, out seenObject, visionDistance))
        {
            if (seenObject.collider.gameObject.CompareTag("InteractObject"))
            {
                print(seenObject.collider.gameObject.name);
            }
        }
    }
}
