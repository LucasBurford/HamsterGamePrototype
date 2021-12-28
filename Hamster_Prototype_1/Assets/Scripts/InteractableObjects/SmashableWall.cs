using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashableWall : MonoBehaviour
{
    public void GetSmashed(Hedgehog hedgehog)
    {
        // Play smashing sound

        // Send message back to Hedgehog saying to stop moving 
        hedgehog.gameObject.SendMessage("SmashSuccessful");

        // Destroy the gameobject
        Destroy(gameObject);
    }
}
